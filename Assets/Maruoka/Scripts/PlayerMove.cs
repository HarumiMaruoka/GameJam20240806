using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;


    [SerializeField]
    private float _acceleration = 10f;
    [SerializeField]
    private float _deceleration = 25f;
    [SerializeField]
    private Vector3 _currentSpeed;
    [SerializeField]
    private float _rotationSpeed = 3f;

    [SerializeField]
    private ItemCatcher _itemCatcher;

    [SerializeField]
    private float _speedWithoutLoad = 15f; // 荷物を持っていない時の速度
    [SerializeField]
    private float _speedWithSmallLoad = 14f; // 小さい荷物を持っている時の速度
    [SerializeField]
    private float _speedWithMediumLoad = 12f; // 中くらいの荷物を持っている時の速度
    [SerializeField]
    private float _speedWithLargeLoad = 10f; // 大きい荷物を持っている時の速度
    [SerializeField]
    private float _speedWithExtraLargeLoad = 8f; // 特大の荷物を持っている時の速度

    public float MaxSpeed
    {
        get
        {
            if (!_itemCatcher.Item) return _speedWithoutLoad;
            switch (_itemCatcher.Item.Size)
            {
                case ItemSize.Small:
                    return _speedWithSmallLoad;
                case ItemSize.Medium:
                    return _speedWithMediumLoad;
                case ItemSize.Large:
                    return _speedWithLargeLoad;
                case ItemSize.ExtraLarge:
                    return _speedWithExtraLargeLoad;
                default:
                    return _speedWithoutLoad;
            }
        }
    }

    private Quaternion _targetRotation;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _targetRotation = transform.rotation;
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
        _currentSpeed.z = Mathf.Clamp(_currentSpeed.z, -MaxSpeed, MaxSpeed);

        // AD キーで左右移動
        if (Input.GetKey(KeyCode.D))
        {
            _currentSpeed.x += _acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _currentSpeed.x -= _acceleration * Time.deltaTime;
        }
        else
        {
            if (_currentSpeed.x > 0)
            {
                _currentSpeed.x -= _deceleration * Time.deltaTime;
                if (_currentSpeed.x < 0) _currentSpeed.x = 0;
            }
            else if (_currentSpeed.x < 0)
            {
                _currentSpeed.x += _deceleration * Time.deltaTime;
                if (_currentSpeed.x > 0) _currentSpeed.x = 0;
            }
        }

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

        _currentSpeed.y = Mathf.Clamp(_currentSpeed.y, -MaxSpeed, MaxSpeed);

        // 速度の大きさを制限
        _currentSpeed = Vector3.ClampMagnitude(_currentSpeed, MaxSpeed);

        _rb.velocity = _mainCamera.transform.TransformDirection(_currentSpeed);
        var velo = _rb.velocity;
        velo.y = _currentSpeed.y;
        _rb.velocity = velo;

        // xz 平面の移動方向を向く
        if (new Vector3(_currentSpeed.x, 0, _currentSpeed.z).magnitude > 0.5f)
        {
            // カメラの前方向を基準にして移動方向を計算
            Vector3 cameraForward = _mainCamera.transform.forward;
            cameraForward.y = 0; // y成分を無視してxz平面に投影
            cameraForward.Normalize();

            Vector3 moveDirection = new Vector3(_currentSpeed.x, 0, _currentSpeed.z);
            moveDirection = Quaternion.LookRotation(cameraForward) * moveDirection;

            _targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
