using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class PlayerMover
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxRotationZ;
    [SerializeField] private int _minRotationZ;
    [SerializeField] private float _fallRotationSpeed;

    private Transform _transform;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;


    public void Initialize(Transform transform)
    {
        _transform = transform;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    public void Jump()
    {
        _rigidbody2D.velocity = Vector2.up * _jumpForce;
        _transform.rotation = _maxRotation;
    }

    public void RotateToFallValue()
    {
        _transform.rotation = Quaternion.Lerp(_transform.rotation, _minRotation, _fallRotationSpeed * Time.deltaTime);
    }
}
