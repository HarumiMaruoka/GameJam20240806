using System;
using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    [SerializeField]
    private Maruoka.ItemGoal _itemGorl;
    [SerializeField]
    private Transform[] potentialGoalPositions;

    private Maruoka.ItemGoal _goal;
    public Maruoka.ItemGoal Goal => _goal;

    // プレイヤーが荷物を手に入れたらゴールを生成する。
    public void SpawnGoal()
    {
        // ゴールを生成する。
        var goalPos = potentialGoalPositions[UnityEngine.Random.Range(0, potentialGoalPositions.Length)];
        _goal = Instantiate(_itemGorl, goalPos.position, Quaternion.identity);
    }
}
