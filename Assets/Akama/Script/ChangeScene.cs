using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// テスト用のスクリプトです。
/// </summary>
public class ChangeScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene("TestScene");
        }
    }
}
