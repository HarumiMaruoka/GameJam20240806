using System;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField]
    private GoalSpawner _goalSpawner;

    [SerializeField]
    private ItemCatcher _itemCatcher;

    private bool _wasItemWithoutGoal;
    // �ו���݂��Ă���̂ɃS�[�����Ȃ��ꍇ true ��Ԃ��B
    private bool IsItemWithoutGoal => _goalSpawner.Goal == null && _itemCatcher.Item != null;

    private void Update()
    {
        if (IsItemWithoutGoal && _wasItemWithoutGoal == false)
        {
            _wasItemWithoutGoal = true;
            Debug.LogWarning("�S�[��������܂���B");
        }
    }
}
