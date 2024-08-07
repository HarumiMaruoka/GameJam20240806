using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemSize _size;

    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private Rigidbody _rigidbody;

    public Collider Collider => _collider;
    public Rigidbody Rigidbody => _rigidbody;

    public ItemSize Size => _size;

    [SerializeField]
    private float _shrinkDuration = 1.0f;
    [SerializeField]
    private ParticleSystem _deadParticlePrefab;

    public async void Dead()
    {
        try
        {
            var localScale = transform.localScale;
            for (float t = 0; t < _shrinkDuration; t += Time.deltaTime)
            {
                transform.localScale = Vector3.Lerp(localScale, Vector3.zero, t / _shrinkDuration);
                await UniTask.Yield(this.GetCancellationTokenOnDestroy());
            }
        }
        catch (OperationCanceledException)
        {
            return;
        }

        Instantiate(_deadParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            Debug.Log("Item ‚ªƒS[ƒ‹‚É“ž’…‚µ‚½B");
            Destroy(gameObject);
        }
    }
}

public enum ItemSize
{
    Small,
    Medium,
    Large,
    ExtraLarge
}