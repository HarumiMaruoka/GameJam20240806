using UnityEngine;

/// <summary>
/// �e�X�g�p�̃X�N���v�g�ł��B
/// </summary>
public class ItemTest : MonoBehaviour
{
    [SerializeField]
    public int _plusScore;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //�Q�[���I�u�W�F�N�g�����������ƁAscore��plusScore��ۑ�����
        {
            if (GameManager._scoreInstance != null)
            {
                GameManager._scoreInstance._gameManagerScore += _plusScore;
            }
        }
    }
}
