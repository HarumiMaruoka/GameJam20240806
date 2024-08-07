using System;
using UnityEngine;

public class DroneAnimation : MonoBehaviour
{
    [SerializeField]
    private Transform[] _droneRotors;

    [SerializeField]
    private float _rotorSpeed = 360f;

    private void Update()
    {
        foreach (var rotor in _droneRotors)
        {
            var rot = rotor.localEulerAngles;
            rot.y += _rotorSpeed * Time.deltaTime;
            rotor.localEulerAngles = rot;
        }
    }
}
