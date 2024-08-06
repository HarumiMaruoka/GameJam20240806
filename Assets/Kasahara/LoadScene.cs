using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    [Header("Panelをいれて名前はFadePanelでImageのRaycastTargetをオフにしてください")]
    /// <summary>フェード用 Image</summary>
    [SerializeField] Image _fadeImage = default;
    [Header("フェードアウトにかかる時間")]
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    [SerializeField] float _fadeTime = 1;
    [Header("フェードアウト完了後に待つ時間")]
    /// <summary>フェードアウト完了後に待つ時間（秒）/summary>
    [SerializeField] float _waitTime = 1;
    float _timer = 0;
    Coroutine _coroutine;
    private string _sceneName;

    InOut _fade = InOut.In;
    // Start is called before the first frame update
    void Start()
    {
        Fade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load(string sceneName)
    {
        _sceneName = sceneName;
        Debug.Log("Clicked");
        Fade();
        Invoke("Load2", _fadeTime+_waitTime);
    }
    private void Load2()
    {
        SceneManager.LoadScene(_sceneName);
    }
    public void Fade()
    {
        StartCoroutine(FadeRoutine());
    }
    IEnumerator FadeRoutine()
    {
        // Image から Color を取得し、時間の進行に合わせたアルファを設定して Image に戻す
        while (true)
        {
            _timer += Time.deltaTime;
            Color c = _fadeImage.color; // 現在の Image の色を取得する
            if (_fade == InOut.Out)
                c.a = _timer / _fadeTime;   // 色のアルファを 1 に近づけていく
            else
                c.a = 1 - _timer / _fadeTime;
            // TODO: 色を Image にセットする
            _fadeImage.color = c;
            // _fadeTime が経過したら処理は終了する
            if (_timer > _fadeTime)
            {
                if (_fade == InOut.In)
                {
                    _fade = InOut.Out;
                    _timer = 0;
                }
                    
                Debug.Log("コルーチンによる Fade 完了");
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
    private enum InOut
    {
        In,
        Out,
    }
}
