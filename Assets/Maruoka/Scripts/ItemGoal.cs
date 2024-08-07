using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Maruoka
{
    public class ItemGoal : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem[] _particleSystems;

        private async void Start()
        {
            try
            {
                while (!_goaled)
                {
                    await UniTask.Yield(this.GetCancellationTokenOnDestroy());
                }

                foreach (var ps in _particleSystems)
                {
                    ps.Stop();
                }

                // 全てのパーティクルがDestroyされるまで待つ
                foreach (var ps in _particleSystems)
                {
                    await UniTask.WaitUntil(() => !ps, cancellationToken: this.GetCancellationTokenOnDestroy());
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }

        private bool _goaled = false;

        private void OnTriggerEnter(Collider other)
        {
            if (_goaled) return;

            if (other.TryGetComponent(out Item item))
            {
                Maruoka.ScoreManager.Instance.AddScore(item.Size);
                item.Dead();
                _goaled = true;
            }
        }
    }
}