using System;
using UnityEngine;
using System.Linq;


public class InputDeviceManager
{
    private static readonly string[] GamepadButtons = new string[]
    {
        "Horizontal2", "Vertical2",
        "R Trigger", "L Trigger"
    };

    private void Update()
    {
        if (IsAnyGamepadButtonPressed())
        {
            Debug.Log("�Q�[���p�b�h�̂ǂꂩ�̃L�[��������܂����B");
        }
    }

    private bool IsAnyGamepadButtonPressed()
    {
        return GamepadButtons.Any(button => Input.GetButton(button) || Input.GetAxis(button) != 0);
    }
}