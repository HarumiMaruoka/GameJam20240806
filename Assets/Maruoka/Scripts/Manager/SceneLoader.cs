using System;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;
    [SerializeField]
    private Image _fadeImage;
    [SerializeField]
    private float _fadeDuration = 1.0f;

    public void LoadScene()
    {
        StartCoroutine(_fadeImage.FadeInAsync(_fadeDuration, () =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
        }));
    }
}
