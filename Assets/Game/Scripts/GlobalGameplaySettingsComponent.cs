using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameplaySettingsComponent : MonoBehaviour
{
    [SerializeField] private float _baseDownSpeed = 10.0f;

    [SerializeField] private int _pointsPerOneRhythmItem = 1;
    
    [SerializeField] private int _pointsPerOneShitItem = 10;

    [SerializeField] private int _pointsPerLevel = 100;

    private float _currentDownSpeed = 0.0f;

    public float DownSpeed => _currentDownSpeed;

    public int PointsPerOneShitItem => _pointsPerOneShitItem;
    
    public int PointsPerLevel => _pointsPerLevel;

    public int PointsPerOneRhythmItem => _pointsPerOneRhythmItem;

    public static GlobalGameplaySettingsComponent Instance =>
        GameObject.Find("MetaGameObjects").GetComponent<GlobalGameplaySettingsComponent>();

    private void Start()
    {
        _currentDownSpeed = _baseDownSpeed;
    }
    
    public void SetSlowSpeed()
    {
        _currentDownSpeed = _baseDownSpeed / 2.0f;
    }    
    
    public void SetNormalSpeed()
    {
        _currentDownSpeed = _baseDownSpeed;
    }
    
    public void SetFastSpeed()
    {
        _currentDownSpeed = _baseDownSpeed * 2.0f;
    }    
}
