using System;
using UnityEngine;

namespace Maruoka
{
    public class ScoreManager
    {
        public static ScoreManager Instance { get; } = new ScoreManager();
        private ScoreManager() { }

        public int Score { get; set; } = 0;

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
                    throw new ArgumentOutOfRangeException(nameof(itemSize), itemSize, null);
            }
        }
    }
}