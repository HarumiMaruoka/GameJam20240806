using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StartCountdownView : MonoBehaviour
{
    [SerializeField]
    private StartCountdown _startCountdown;

    private Text _countdownText;

    private void Awake()
    {
        _countdownText = GetComponent<Text>();
    }

    private void Update()
    {
        _countdownText.text = _startCountdown.CurrentTime.ToString("F0");
        if (_startCountdown.CurrentTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
