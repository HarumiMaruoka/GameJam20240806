using System;
using UnityEngine;

public class ScoreManager
{
    public static ScoreManager Instance { get; } = new ScoreManager();
    private ScoreManager() { }

    private int _score = 0;
    public event Action<int> OnScoreChanged;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            OnScoreChanged?.Invoke(_score);
        }
    }

    public void AddScore(ItemSize itemSize)
    {
        switch (itemSize)
        {
            case ItemSize.Small:
                SEPlayer.PlaySE("good");
                Score += 1000;
                break;
            case ItemSize.Medium:
                SEPlayer.PlaySE("goal");
                Score += 2000;
                break;
            case ItemSize.Large:
                SEPlayer.PlaySE("marvelous");
                Score += 3000;
                break;
            case ItemSize.ExtraLarge:
                SEPlayer.PlaySE("excellent");
                Score += 4000;
                break;
            default:
                Debug.LogError("Invalid item size");
                break;
        }
    }
}