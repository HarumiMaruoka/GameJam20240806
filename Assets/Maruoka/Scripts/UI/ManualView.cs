using System;
using UnityEngine;

public class ManualView : MonoBehaviour
{
    [SerializeField]
    private GameObject keyboardManual;
    [SerializeField]
    private GameObject gamepadManual;

    private void Update()
    {
        if (InputDeviceManager.CurrentInputDevice == InputDevice.Keyboard)
        {
            keyboardManual.SetActive(true);
            gamepadManual.SetActive(false);
        }
        else
        {
            keyboardManual.SetActive(false);
            gamepadManual.SetActive(true);
        }
    }
}
