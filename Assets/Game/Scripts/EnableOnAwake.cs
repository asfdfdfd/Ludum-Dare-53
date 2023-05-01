using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnAwake : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    private void Awake()
    {
        _gameObject.SetActive(true);
    }
}
