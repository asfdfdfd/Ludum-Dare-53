using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySceneController : MonoBehaviour
{
    [SerializeField] private BirdController _birdController;

    [SerializeField] private RhythmItemsController _rhythmItemsController;
    
    [SerializeField] private float _levelLengthInSeconds = 10.0f;

    [SerializeField] private GameObject _endTreePrefab;
    
    [SerializeField] private GameObject _endTreeSpawnPoint;
    
    private bool _isLevelEndTimerEnabled = true;
    private float _levelEndTimer = 0.0f;
    
    private void Start()
    {
        _birdController.MoveToStartupLane();
        _birdController.levelEndEvent.AddListener(() =>
        {
            StartLevelEnd();
        });
    }

    private void Update()
    {
        if (_isLevelEndTimerEnabled)
        {
            _levelEndTimer += Time.deltaTime;

            if (_levelEndTimer >= _levelLengthInSeconds)
            {
                _rhythmItemsController.EndLevel();
                
                _isLevelEndTimerEnabled = false;
            }
        }
    }

    private void StartLevelEnd()
    {
        Instantiate(_endTreePrefab, _endTreeSpawnPoint.transform.position, Quaternion.identity);
    }
}
