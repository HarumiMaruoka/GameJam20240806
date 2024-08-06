using System;
using UnityEngine;

public class ItemCatcher : MonoBehaviour
{
    [SerializeField]
    private Transform _itemPosition;

    private Item _item;

    private void OnTriggerEnter(Collider other)
    {
        if (_item) return;

        if (other.TryGetComponent(out Item item))
        {
            _item = item;
            Debug.Log($"ItemCatcher が Item をキャッチした。Item のサイズは {item.Size} です。");
            item.transform.position = _itemPosition.position;
            item.transform.SetParent(_itemPosition);
        }
    }
}
