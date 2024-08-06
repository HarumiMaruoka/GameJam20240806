using UnityEngine;

/// <summary>
/// �S�[���ɂ������v���n�u�ɃA�^�b�`���Ă��������B
/// �v���C���[�̃^�O�ɑ΂���ڐG�𔻒肷��B
/// </summary>
public class ItemTriggerCheck : MonoBehaviour
{
    // �����蔻����`�F�b�N����B
    [HideInInspector] 
    public bool _on = false;

    private string _item = "Item";

    // Tag��Item(_item)�̂��̂ɐڐG�������B
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _item)
        {
            _on = true;
            Destroy(this.gameObject);
        }
    }

    // Tag��Item(_item)�̂��̂Ƃ̐ڐG����߂����B
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == _item)
        {
            _on = false;
        }
    }
}
