using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoopRotator : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectPoop;
    
    private float _rotationSpeed = 50.0f;

    private void Update()
    {
        var xLength = _rotationSpeed * Random.Range(1, 5) * Time.deltaTime;
        var yLength = _rotationSpeed * Random.Range(1, 5) * Time.deltaTime;
        var zLength = _rotationSpeed * Random.Range(1, 5) * Time.deltaTime;
        
        _gameObjectPoop.transform.Rotate(xLength, yLength, zLength, Space.Self);
    }
}
