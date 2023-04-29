using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmItemController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 position = _rigidbody.position;
        position.z -= _speed * Time.fixedDeltaTime;
        
        _rigidbody.MovePosition(position);
    }
}
