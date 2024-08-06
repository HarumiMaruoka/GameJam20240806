using UnityEngine;

/// <summary>
/// ゴールにしたいプレハブにアタッチしてください。
/// プレイヤーのタグに対する接触を判定する。
/// </summary>
public class ItemTriggerCheck : MonoBehaviour
{
    // 当たり判定をチェックする。
    [HideInInspector] 
    public bool _on = false;

    private string _item = "Item";

    // TagがItem(_item)のものに接触した時。
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _item)
        {
            _on = true;
            Destroy(this.gameObject);
        }
    }

    // TagがItem(_item)のものとの接触をやめた時。
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == _item)
        {
            _on = false;
        }
    }
}
