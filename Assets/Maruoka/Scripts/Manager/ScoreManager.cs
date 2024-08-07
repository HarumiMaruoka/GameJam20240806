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
                Score += 100;
                break;
            case ItemSize.Medium:
                Score += 200;
                break;
            case ItemSize.Large:
                Score += 300;
                break;
            case ItemSize.ExtraLarge:
                Score += 400;
                break;
            default:
                Debug.LogError("Invalid item size");
                break;
        }
    }
}