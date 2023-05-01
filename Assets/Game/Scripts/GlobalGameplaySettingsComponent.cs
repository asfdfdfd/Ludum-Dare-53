using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;

public class GlobalGameplaySettingsComponent : MonoBehaviour
{
    [SerializeField] private float _baseDownSpeed = 10.0f;

    [SerializeField] private int _pointsPerOneRhythmItem = 1;
    
    [SerializeField] private int _pointsPerOneShitItem = 10;

    [SerializeField] private int _pointsPerLevel = 100;

    private float _currentDownSpeed;

    private SpeedType _currentSpeedType;
    
    public float DownSpeed => _currentDownSpeed;

    public int PointsPerOneShitItem => _pointsPerOneShitItem;
    
    public int PointsPerLevel => _pointsPerLevel;

    public int PointsPerOneRhythmItem => _pointsPerOneRhythmItem;

    public static GlobalGameplaySettingsComponent Instance;
    
    private void Awake()
    {
        Instance = GameObject.Find("MetaGameObjects").GetComponent<GlobalGameplaySettingsComponent>();
        
        SetNormalSpeed();
    }

    public void SetSlowSpeed()
    {
        _currentSpeedType = SpeedType.SLOW;
        _currentDownSpeed = _baseDownSpeed - _baseDownSpeed * 0.2f;
    }    
    
    public void SetNormalSpeed()
    {
        _currentSpeedType = SpeedType.NORMAL;
        _currentDownSpeed = _baseDownSpeed;
    }

    public float GetNormalSpeed()
    {
        return _baseDownSpeed;
    }
    
    public void SetFastSpeed()
    {
        _currentSpeedType = SpeedType.FAST;
        _currentDownSpeed = (_baseDownSpeed + _baseDownSpeed * 0.2f + _baseDownSpeed * 0.2f + _baseDownSpeed * 0.2f + _baseDownSpeed * 0.2f);
    }

    public SpeedType GetSpeedType()
    {
        return _currentSpeedType;
    }
    
}
