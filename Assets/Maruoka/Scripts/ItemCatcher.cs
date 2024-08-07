using System;
using UnityEngine;

public class ItemCatcher : MonoBehaviour
{
    [SerializeField]
    private Transform _itemPosition;
    [SerializeField]
    private GoalSpawner _goalSpawner;

    private Item _item;

    public Item Item => _item;

    private void OnTriggerEnter(Collider other)
    {
        if (_item) return;

        if (other.TryGetComponent(out Item item))
        {
            _item = item;
            _goalSpawner.SpawnGoal();
            item.transform.rotation = Quaternion.identity;
            Destroy(item.Rigidbody);
            item.transform.position = _itemPosition.position;
            item.transform.SetParent(_itemPosition);
        }
    }
}
