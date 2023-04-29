using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownComponent : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 position = _rigidbody.position;
        position.z -= GlobalGameplaySettingsComponent.Instance.DownSpeed * Time.fixedDeltaTime;
        
        _rigidbody.MovePosition(position);
    }
}
