using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += new Vector3(_speed * Time.deltaTime, 0);

        if (transform.position.x <= _maxPositionX)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.position = Vector3.zero;
    }
}
