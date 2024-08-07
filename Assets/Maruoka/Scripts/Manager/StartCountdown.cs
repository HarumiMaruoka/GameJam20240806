using Cinemachine;
using System;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{
    public static event Action OnCountdownFinished;
    [SerializeField] private Image _fadeImage;
    [SerializeField] private float _countdownTime = 3f;
    [SerializeField] private float _fadeDuration = 1.0f;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private BGMPlayer _bgmPlayer;

    public float CurrentTime { get; private set; }

    private void Awake()
    {
        _bgmPlayer.PlayBGM();

        _cinemachineVirtualCamera.enabled = false;
        GameManager.Instance.IsGameStarted = false;

        StartCoroutine(Countdown());
    }

    private System.Collections.IEnumerator Countdown()
    {
        CurrentTime = _countdownTime;
        yield return _fadeImage.FadeOutAsync(_fadeDuration);

        while (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            yield return null;
        }

        OnCountdownFinished?.Invoke();
        gameObject.SetActive(false);

        GameManager.Instance.IsGameStarted = true;
        _cinemachineVirtualCamera.enabled = true;
    }
}
