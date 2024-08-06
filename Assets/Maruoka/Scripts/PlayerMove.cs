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
        // WS �L�[�őO��ړ�
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

        // �}�E�X���E�{�^���ŏ㉺�ړ�
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

        // �}�E�X�̈ړ��ʂŉ�]
        float mx = Input.GetAxis("Mouse X");//�J�[�\���̉��̈ړ��ʂ��擾
        if (Mathf.Abs(mx) > 0.001f) // X�����Ɉ��ʈړ����Ă���Ή���]
        {
            transform.RotateAround(transform.position, Vector3.up, mx * _rotationSpeed); // ��]����player�I�u�W�F�N�g�̃��[���h���WY��
        }

        _currentSpeed.y = Mathf.Clamp(_currentSpeed.y, -_maxSpeed, _maxSpeed);

        _rb.velocity = _mainCamera.transform.TransformDirection(_currentSpeed);
    }
}
