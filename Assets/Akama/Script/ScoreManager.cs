using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// �V�[���ɕ\�������X�R�A
    /// DontDestroyOnLoad�̃X�R�A��_gameManagerScore
    /// </summary>
    [SerializeField]
    int _score = 0;

    /// <summary>
    /// �X�R�A�Ƃ��ĕ\���������e�L�X�g
    /// </summary>
    [SerializeField]
    Text _scoreText;

    void Start()
    {
        _scoreText.text = "�X�R�A: " + GameManager._scoreInstance._gameManagerScore.ToString();
    }

    void Update()
    {
        //_score��GameManager�̎���_gameManagerScore�ƈႤ�ꍇ�A_score�̒l�𓯂��ɂ��A�e�L�X�g�̕\�����ς���B
        if (_score != GameManager._scoreInstance._gameManagerScore)
        {
            _scoreText.text = "�X�R�A: " + GameManager._scoreInstance._gameManagerScore.ToString();
            _score = GameManager._scoreInstance._gameManagerScore;
        }
    }
}
