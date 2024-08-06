using UnityEngine;
using UnityEngine.UI;
public class TimeEvent : MonoBehaviour
{
    // �^�C�}�[
    [SerializeField]
    float _timer = 5f;

    /// <summary>
    /// �C�x���g��������ꍇ���̉��ɒǉ����Ă���
    /// </summary>
    [SerializeField]
    float _event1 = 0f;

    /// <summary>
    /// �}�C�i�X�̒l�ɂ��Ă����B�^�C�}�[������A�C�e��������ꍇ�͂��̒l��傫������B
    /// </summary>
    [SerializeField]
    float _endEvent = -1f;

    /// <summary>
    /// �^�C�}�[�Ƃ��ĕ\���������e�L�X�g
    /// </summary>
    [SerializeField]
    Text _timerText;

    void Start()
    {
    }

    void Update()
    {
        // �����_�ȉ��̐�����\���������ꍇn�ȍ~�̐�����ύX����B
        _timerText.text = _timer.ToString("n2");

        // �^�C�}�[������̕ϐ��������������s�B�^�C�}�[��0������邱�Ƃ͂Ȃ��̂�
        if (_timer <= _event1)
        {
            Debug.Log("�C�x���g1�����s");
            _event1 = _endEvent;
        }

        // �^�C�}�[��0�����������^�C�}�[���~�߂�B
        if (_timer > 0) _timer -= Time.deltaTime;
    }
}
