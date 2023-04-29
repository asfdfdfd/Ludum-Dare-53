using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndTreeController : MonoBehaviour
{
    private Vector3 _scaleNormal;

    private void Awake()
    {
        _scaleNormal = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void Start()
    {
        transform.DOScale(_scaleNormal, 1.0f).SetEase(Ease.OutBounce);
    }
}
