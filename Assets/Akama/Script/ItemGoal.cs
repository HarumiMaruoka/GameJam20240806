using UnityEngine;

public class ItemGoal : MonoBehaviour
{
    /// <summary>
    /// 加算するスコアをアイテムごとに設定する。
    /// </summary>
    [SerializeField] 
    public int _plusScore;

    /// <summary>
    /// ItemTriggerCheckのbool。
    /// </summary>
    [SerializeField]
    public ItemTriggerCheck _check;

    private void Update()
    {
        if (_check._on)    //ゲームオブジェクトを消す処理と、scoreにplusScoreを保存する
        {
            if (GameManager._scoreInstance != null)
            {
                GameManager._scoreInstance._gameManagerScore += _plusScore;
                Destroy(this.gameObject);
            }
        }
    }
}
