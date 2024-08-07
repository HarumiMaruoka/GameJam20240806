using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Transform _transform;
    [SerializeField] float _veloX;
    [SerializeField] float _veloY;
    [SerializeField] float _veloZ;
    void Start()
    {
        _transform = transform;
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(Time.timeSinceLevelLoad * _veloX, Time.timeSinceLevelLoad * _veloY, Time.timeSinceLevelLoad * _veloZ);
    }
}
