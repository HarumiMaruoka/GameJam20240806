using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    [SerializeField] float _windPower;
    private Vector3 _windDir = Vector3.zero;
    Transform _transform;
    private void Update()
    {
        _windDir = transform.forward;
    }
    private void OnTriggerStay(Collider other)
    {
            Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb != null) 
            rb.AddForce(_windDir * _windPower, ForceMode.Force);
    }
}
