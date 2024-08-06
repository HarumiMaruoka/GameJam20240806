using UnityEngine;

public class ItemGoal : MonoBehaviour
{
    /// <summary>
    /// ���Z����X�R�A���A�C�e�����Ƃɐݒ肷��B
    /// </summary>
    [SerializeField] 
    public int _plusScore;

    /// <summary>
    /// ItemTriggerCheck��bool�B
    /// </summary>
    [SerializeField]
    public ItemTriggerCheck _check;

    private void Update()
    {
        if (_check._on)    //�Q�[���I�u�W�F�N�g�����������ƁAscore��plusScore��ۑ�����
        {
            if (GameManager._scoreInstance != null)
            {
                GameManager._scoreInstance._gameManagerScore += _plusScore;
                Destroy(this.gameObject);
            }
        }
    }
}
