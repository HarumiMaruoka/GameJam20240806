using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _scoreInstance = null;
    public int _gameManagerScore = 0;

    private void Awake()
    {
        if (_scoreInstance == null)
        {
            _scoreInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
