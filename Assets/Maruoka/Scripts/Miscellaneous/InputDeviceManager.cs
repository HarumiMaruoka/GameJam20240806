using System;
using UnityEngine;
using System.Linq;

public class InputDeviceManager : MonoBehaviour
{
    public static InputDevice CurrentInputDevice { get; private set; } = InputDevice.Keyboard;

    private static readonly string[] GamepadButtons = new string[]
    {
        "Horizontal2", "Vertical2",
        "R Trigger", "L Trigger"
    };

    private void Update()
    {
        if (IsAnyGamepadButtonPressed()) CurrentInputDevice = InputDevice.Gamepad;
        if (IsAnyKeybordMouseButtonPressed()) CurrentInputDevice = InputDevice.Keyboard;
    }

    private bool IsAnyGamepadButtonPressed()
    {
        return GamepadButtons.Any(button => Input.GetButton(button) || Input.GetAxis(button) > 0.1f);
    }

    private bool IsAnyKeybordMouseButtonPressed()
    {
        return Input.anyKey;
    }
}

public enum InputDevice
{
    Keyboard,
    Gamepad
}