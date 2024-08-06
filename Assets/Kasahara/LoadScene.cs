using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    /// <summary>�t�F�[�h�p Image</summary>
    [SerializeField] Image _fadeImage = default;
    [Header("�t�F�[�h�A�E�g�ɂ����鎞��")]
    /// <summary>�t�F�[�h�A�E�g�����܂łɂ����鎞�ԁi�b�j/summary>
    [SerializeField] float _fadeTime = 1;
    [Header("�t�F�[�h�A�E�g������ɑ҂���")]
    /// <summary>�t�F�[�h�A�E�g������ɑ҂��ԁi�b�j/summary>
    [SerializeField] float _waitTime = 1;
    float _timer = 0;
    Coroutine _coroutine;
    private string _sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load(string sceneName)
    {
        _sceneName = sceneName;
        Debug.Log("Clicked");
        FadeIn();
        Invoke("Load2", _fadeTime+_waitTime);
    }
    private void Load2()
    {
        SceneManager.LoadScene(_sceneName);
    }
    public void FadeIn()
    {
        StartCoroutine(FadeRoutine());
    }
    IEnumerator FadeRoutine()
    {
        // Image ���� Color ���擾���A���Ԃ̐i�s�ɍ��킹���A���t�@��ݒ肵�� Image �ɖ߂�
        while (true)
        {
            _timer += Time.deltaTime;
            Color c = _fadeImage.color; // ���݂� Image �̐F���擾����
            c.a = _timer / _fadeTime;   // �F�̃A���t�@�� 1 �ɋ߂Â��Ă���
            // TODO: �F�� Image �ɃZ�b�g����
            _fadeImage.color = c;
            // _fadeTime ���o�߂����珈���͏I������
            if (_timer > _fadeTime)
            {
                Debug.Log("�R���[�`���ɂ�� Fade ����");
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
