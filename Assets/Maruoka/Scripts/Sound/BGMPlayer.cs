using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGMPlayer : MonoBehaviour
{
    private static BGMPlayer _instance; // åªç›çƒê∂íÜÇÃBGMPlayer

    [SerializeField]
    private AudioClip _bgm;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
    }

    public void PlayBGM()
    {
        if (_instance != null)
        {
            _instance.StopBGM();
        }

        _instance = this;
        if (!_audioSource)
        {
            Debug.LogError("BGMPlayer is not attached to any GameObject.");
            return;
        }
        _audioSource.clip = _bgm;
        _audioSource.Play();
    }

    public void StopBGM()
    {
        _instance = null;
        if (!_audioSource)
        {
            Debug.LogError("BGMPlayer is not attached to any GameObject.");
            return;
        }
        _audioSource.Stop();
    }
}
