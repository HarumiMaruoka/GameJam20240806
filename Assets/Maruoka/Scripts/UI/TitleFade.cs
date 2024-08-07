using System;
using UnityEngine;
using UnityEngine.UI;

public class TitleFade : MonoBehaviour
{
    [SerializeField]
    private Image _fadeImage;
    [SerializeField]
    private float _fadeTime = 1.0f;
    [SerializeField]
    private BGMPlayer _bgmPlayer;

    private void Start()
    {
        _bgmPlayer.PlayBGM();
        StartCoroutine(_fadeImage.FadeOutAsync(_fadeTime));
    }
}
