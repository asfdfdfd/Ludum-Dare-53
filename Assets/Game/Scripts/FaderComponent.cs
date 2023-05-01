using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FaderComponent : MonoBehaviour
{
    private Image _image;
    
    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void TurnOn()
    {
        _image.enabled = true;
    }

    public void TurnOff()
    {
        _image.enabled = false;
    }

    public IEnumerator ToBlack()
    {
        yield return _image.DOFade(1.0f, 0.3f).WaitForCompletion();
    }

    public IEnumerator ToAlpha()
    {
        yield return _image.DOFade(0.0f, 0.3f).WaitForCompletion();
    }
}
