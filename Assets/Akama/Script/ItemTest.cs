using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    public int _plusScore;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //ゲームオブジェクトを消す処理と、scoreにplusScoreを保存する
        {
            if (GameManager._scoreInstance != null)
            {
                GameManager._scoreInstance._gameManagerScore += _plusScore;
            }
        }
    }
}
