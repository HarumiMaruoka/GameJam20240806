using Cinemachine;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private float _time;
    [SerializeField]
    private TimeupView _timeupView;
    [SerializeField]
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField]
    private PlayerMove _playerMove;
    [SerializeField]
    private CursorLock _cursorLock;
    [SerializeField]
    private BGMPlayer _resultBgmPlayer;

    private TimeSpan _timer;

    private void Awake()
    {
        ScoreManager.Instance.Score = 0;
    }

    private void Start()
    {
        _timer = TimeSpan.FromSeconds(_time);
        _text.text = _timer.ToString(@"mm\:ss");
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameStarted) return;
        if (_timer < new TimeSpan(0)) return;

        _timer = _timer.Subtract(TimeSpan.FromSeconds(Time.deltaTime));
        _text.text = _timer.ToString(@"mm\:ss");

        if (_timer.TotalSeconds <= 0)
        {
            GameManager.Instance.IsGameStarted = false;
            _cinemachineVirtualCamera.enabled = false;
            _timeupView.Show();
            _playerMove.Stop();
            _cursorLock.Unlock();
            _resultBgmPlayer.PlayBGM();
        }
    }
}
