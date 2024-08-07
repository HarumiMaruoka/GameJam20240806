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
        // �A�C�e���������Ă��ăS�[�����Ȃ��Ƃ���������
        if (_item && !_goalSpawner.Goal)
        {
            _goalSpawner.SpawnGoal();
        }

        if (_item) return;

        // �^���Ƀ��C���΂�
        Physics.Raycast(transform.position, Vector3.down, out var hit, 1);
        if (hit.collider == null) return;
        if (hit.collider.TryGetComponent(out Item item))
        {
            _item = item;
            // �A�C�e���̃��C���[��ύX����
            item.gameObject.layer = LayerMask.NameToLayer("Item");
            _goalSpawner.SpawnGoal();
            item.transform.rotation = Quaternion.identity;
            Destroy(item.Rigidbody);
            item.transform.position = _itemPosition.position;
            item.transform.SetParent(_itemPosition);
        }
    }
}
