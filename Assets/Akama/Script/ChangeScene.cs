using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �e�X�g�p�̃X�N���v�g�ł��B
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
