using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimeupView : MonoBehaviour
{
    [SerializeField]
    private float _animationDuration = 1.0f;
    [SerializeField]
    private RectTransform _rectTransform;
    [SerializeField]
    private float _waitDuration = 1.0f;
    [SerializeField]
    private ResultView _resultView;

    public void Show()
    {
        // ��ʏ㕔����A��ʒ����Ɉړ�����A�j���[�V����
        StartCoroutine(ShowCoroutine());
    }

    private IEnumerator ShowCoroutine()
    {
        // ��ʏ㕔����A��ʒ����Ɉړ�����A�j���[�V����
        _rectTransform.anchoredPosition = new Vector2(0, Screen.height);
        for (float t = 0; t < _animationDuration; t += Time.deltaTime)
        {
            _rectTransform.anchoredPosition = Vector2.Lerp(new Vector2(0, Screen.height), Vector2.zero, t / _animationDuration);
            yield return null;
        }
        _rectTransform.anchoredPosition = Vector2.zero;

        for (float t = 0; t < _waitDuration; t += Time.deltaTime)
        {
            yield return null;
        }

        _resultView.Show(_animationDuration);

        for (float t = 0; t < _animationDuration; t += Time.deltaTime)
        {
            _rectTransform.anchoredPosition = Vector2.Lerp(Vector2.zero, new Vector2(0, -Screen.height), t / _animationDuration);
            yield return null;
        }

        _rectTransform.anchoredPosition = new Vector2(0, -Screen.height);
    }
}
