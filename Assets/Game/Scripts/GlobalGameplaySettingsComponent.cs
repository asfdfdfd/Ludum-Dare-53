using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameplaySettingsComponent : MonoBehaviour
{
    [SerializeField] private float _baseDownSpeed = 10.0f;

    [SerializeField] private int _pointsPerOneRhythmItem = 1;
    
    [SerializeField] private int _pointsPerOneShitItem = 10;

    [SerializeField] private int _pointsPerLevel = 100;
    
    public float DownSpeed => _baseDownSpeed;

    public int PointsPerOneShitItem => _pointsPerOneShitItem;
    
    public int PointsPerLevel => _pointsPerLevel;

    public int PointsPerOneRhythmItem => _pointsPerOneRhythmItem;

    public static GlobalGameplaySettingsComponent Instance =>
        GameObject.Find("MetaGameObjects").GetComponent<GlobalGameplaySettingsComponent>();
}
