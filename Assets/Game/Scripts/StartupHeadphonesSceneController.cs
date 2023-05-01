using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartupHeadphonesSceneController : MonoBehaviour
{
    [SerializeField] private String _sceneName;

    [SerializeField] private FaderComponent _fader;
    
    private AudioSource _audioSource;

    private bool _isSpaceAlreadyPressed;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(_fader.ToAlpha());
    }

    private void Update()
    {
        if (!_isSpaceAlreadyPressed && Input.GetKeyDown(KeyCode.Space))
        {
            _isSpaceAlreadyPressed = true;
            _audioSource.Play();
            StartCoroutine(StartFadingAndMoving());
        }
    }

    private IEnumerator StartFadingAndMoving()
    {
        yield return _fader.ToBlack();
        
        SceneManager.LoadScene(_sceneName);
    }
}
