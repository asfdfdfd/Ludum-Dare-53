using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShitometerController : MonoBehaviour
{
    private Image _image;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        _image.fillAmount = (float)GameState.PointsCollected / (float)GlobalGameplaySettingsComponent.Instance.PointsPerLevel;
    }
}
