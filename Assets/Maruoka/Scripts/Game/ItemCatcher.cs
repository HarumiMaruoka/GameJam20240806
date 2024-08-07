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

    private void Update()
    {
        // アイテムを持っていてゴールがないとき生成する
        if (_item && !_goalSpawner.Goal)
        {
            _goalSpawner.SpawnGoal();
        }

        if (_item) return;

        // 真下にレイを飛ばす
        Physics.Raycast(transform.position, Vector3.down, out var hit, 1);
        if (hit.collider == null) return;
        if (hit.collider.TryGetComponent(out Item item))
        {
            _item = item;
            // アイテムのレイヤーを変更する
            item.gameObject.layer = LayerMask.NameToLayer("Item");
            _goalSpawner.SpawnGoal();
            item.transform.rotation = Quaternion.identity;
            Destroy(item.Rigidbody);
            item.transform.position = _itemPosition.position;
            item.transform.SetParent(_itemPosition);
        }
    }
}
