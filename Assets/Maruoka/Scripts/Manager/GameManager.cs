using System;
using UnityEngine;

public class GameManager
{
    public static GameManager Instance { get; } = new GameManager();
    private GameManager() { }

    public bool IsGameStarted { get; set; }
}
