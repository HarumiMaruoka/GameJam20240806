using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemSize _size;

    public ItemSize Size => _size;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            Debug.Log("Item ‚ªƒS[ƒ‹‚É“’…‚µ‚½B");
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