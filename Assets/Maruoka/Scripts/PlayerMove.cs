using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;

    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _acceleration;
    [SerializeField]
    private float _deceleration;
    [SerializeField]
    private Vector3 _currentSpeed;
    [SerializeField]
    private float _maxRotationSpeed;

    [SerializeField]
    private float _rotationSpeed = 1f;

    private Vector2 _lastMousePos;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _lastMousePos = Input.mousePosition;
    }

    private void Update()
    {
        // WS キーで前後移動
        if (Input.GetKey(KeyCode.W))
        {
            _currentSpeed.z += _acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _currentSpeed.z -= _acceleration * Time.deltaTime;
        }
        else
        {
            if (_currentSpeed.z > 0)
            {
                _currentSpeed.z -= _deceleration * Time.deltaTime;
                if (_currentSpeed.z < 0) _currentSpeed.z = 0;
            }
            else if (_currentSpeed.z < 0)
            {
                _currentSpeed.z += _deceleration * Time.deltaTime;
                if (_currentSpeed.z > 0) _currentSpeed.z = 0;
            }
        }
        _currentSpeed.z = Mathf.Clamp(_currentSpeed.z, -_maxSpeed, _maxSpeed);

        // マウス左右ボタンで上下移動
        if (Input.GetMouseButton(0))
        {
            _currentSpeed.y += _acceleration * Time.deltaTime;
        }
        else if (Input.GetMouseButton(1))
        {
            _currentSpeed.y -= _acceleration * Time.deltaTime;
        }
        else
        {
            if (_currentSpeed.y > 0)
            {
                _currentSpeed.y -= _deceleration * Time.deltaTime;
                if (_currentSpeed.y < 0) _currentSpeed.y = 0;
            }
            else if (_currentSpeed.y < 0)
            {
                _currentSpeed.y += _deceleration * Time.deltaTime;
                if (_currentSpeed.y > 0) _currentSpeed.y = 0;
            }
        }

        // マウスの移動量で回転
        float mx = Input.GetAxis("Mouse X");//カーソルの横の移動量を取得
        if (Mathf.Abs(mx) > 0.001f) // X方向に一定量移動していれば横回転
        {
            transform.RotateAround(transform.position, Vector3.up, mx * _rotationSpeed); // 回転軸はplayerオブジェクトのワールド座標Y軸
        }

        _currentSpeed.y = Mathf.Clamp(_currentSpeed.y, -_maxSpeed, _maxSpeed);

        _rb.velocity = _mainCamera.transform.TransformDirection(_currentSpeed);
    }
}
