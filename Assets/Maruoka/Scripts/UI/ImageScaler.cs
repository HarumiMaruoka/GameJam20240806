using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ImageScaler : MonoBehaviour
{
    [SerializeField]
    private float _scaleDuration = 1.0f;
    [SerializeField]
    private float _maxScale = 1.5f;
    [SerializeField]
    private float _minScale = 0.5f;

    private async void Start()
    {
        try
        {
            while (true)
            {
                for (float t = 0; t < _scaleDuration; t += Time.deltaTime)
                {
                    float scale = Mathf.Lerp(_minScale, _maxScale, t / _scaleDuration);
                    transform.localScale = new Vector3(scale, scale, 1);
                    await UniTask.Yield(this.GetCancellationTokenOnDestroy());
                }

                for (float t = 0; t < _scaleDuration; t += Time.deltaTime)
                {
                    float scale = Mathf.Lerp(_maxScale, _minScale, t / _scaleDuration);
                    transform.localScale = new Vector3(scale, scale, 1);
                    await UniTask.Yield(this.GetCancellationTokenOnDestroy());
                }
            }
        }
        catch (OperationCanceledException)
        {
            return;
        }
    }
}
