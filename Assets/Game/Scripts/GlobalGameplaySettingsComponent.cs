using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameplaySettingsComponent : MonoBehaviour
{
    [SerializeField] private float _baseDownSpeed = 10.0f;

    public float DownSpeed => _baseDownSpeed;

    public static GlobalGameplaySettingsComponent Instance =>
        GameObject.Find("MetaGameObjects").GetComponent<GlobalGameplaySettingsComponent>();
}
