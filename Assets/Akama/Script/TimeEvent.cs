using UnityEngine;
using UnityEngine.UI;
public class TimeEvent : MonoBehaviour
{
    // タイマー
    [SerializeField]
    float _timer = 5f;

    /// <summary>
    /// イベントが増える場合この下に追加していく
    /// </summary>
    [SerializeField]
    float _event1 = 0f;

    /// <summary>
    /// マイナスの値にしておく。タイマーが減るアイテムがある場合はこの値を大きくする。
    /// </summary>
    [SerializeField]
    float _endEvent = -1f;

    /// <summary>
    /// タイマーとして表示したいテキスト
    /// </summary>
    [SerializeField]
    Text _timerText;

    void Start()
    {
    }

    void Update()
    {
        // 小数点以下の数字を表示したい場合n以降の数字を変更する。
        _timerText.text = _timer.ToString("n2");

        // タイマーが特定の変数を下回ったら実行。タイマーが0を下回ることはないので
        if (_timer <= _event1)
        {
            Debug.Log("イベント1を実行");
            _event1 = _endEvent;
        }

        // タイマーが0を下回ったらタイマーを止める。
        if (_timer > 0) _timer -= Time.deltaTime;
    }
}
