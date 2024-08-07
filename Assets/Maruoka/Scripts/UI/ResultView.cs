using System;
using System.Collections;
using UnityEngine;

public class ResultView : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rectTransform;

    public void Show(float duration)
    {
        StartCoroutine(ShowAsync(duration));
    }

    private IEnumerator ShowAsync(float duration)
    {
        _rectTransform.anchoredPosition = new Vector2(0, Screen.height);
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            _rectTransform.anchoredPosition = Vector2.Lerp(new Vector2(0, Screen.height), Vector2.zero, t / duration);
            yield return null;
        }
        _rectTransform.anchoredPosition = Vector2.zero;
    }
}
