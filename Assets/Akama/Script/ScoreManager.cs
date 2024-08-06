using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// シーンに表示されるスコア
    /// DontDestroyOnLoadのスコアは_gameManagerScore
    /// </summary>
    [SerializeField]
    int _score = 0;

    /// <summary>
    /// スコアとして表示したいテキスト
    /// </summary>
    [SerializeField]
    Text _scoreText;

    void Start()
    {
        _scoreText.text = "スコア: " + GameManager._scoreInstance._gameManagerScore.ToString();
    }

    void Update()
    {
        //_scoreがGameManagerの持つ_gameManagerScoreと違う場合、_scoreの値を同じにし、テキストの表示も変える。
        if (_score != GameManager._scoreInstance._gameManagerScore)
        {
            _scoreText.text = "スコア: " + GameManager._scoreInstance._gameManagerScore.ToString();
            _score = GameManager._scoreInstance._gameManagerScore;
        }
    }
}
