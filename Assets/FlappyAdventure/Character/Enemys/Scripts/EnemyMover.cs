using System;
using UnityEngine;

[Serializable]
public class EnemyMover
{
    [SerializeField] private float _speed;

    private Transform _transform;

    public void Intialize(Transform transform)
    {
        _transform = transform;
    }

    public void Move()
    {
        _transform.position += new Vector3(_speed * Time.deltaTime, 0);
    }
}
