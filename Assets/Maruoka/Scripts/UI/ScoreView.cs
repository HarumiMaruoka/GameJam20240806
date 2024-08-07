using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private Text _view;

    private int _currentScore;
    private Coroutine _scoreChangeCoroutine;

    private void Start()
    {
        _currentScore = ScoreManager.Instance.Score;
        OnScoreChanged(_currentScore);
        ScoreManager.Instance.OnScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        if (_scoreChangeCoroutine != null)
        {
            StopCoroutine(_scoreChangeCoroutine);
        }
        _scoreChangeCoroutine = StartCoroutine(AnimateScoreChange(newScore));
    }

    private IEnumerator AnimateScoreChange(int newScore)
    {
        int startScore = _currentScore;
        float duration = 0.5f; // アニメーションの持続時間
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            _currentScore = (int)Mathf.Lerp(startScore, newScore, elapsed / duration);
            _view.text = $"Score: {_currentScore.ToString("00000")}";
            yield return null;
        }

        _currentScore = newScore;
        _view.text = $"Score: {_currentScore.ToString("00000")}";
    }
}