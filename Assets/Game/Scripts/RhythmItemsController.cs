using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using Game.Scripts.RhythmItemsSegments;
using UnityEngine;
using Random = UnityEngine.Random;

public class RhythmItemsController : MonoBehaviour
{
    [SerializeField] private GameObject _prefabRhythmItem;
    [SerializeField] private GameObject _prefabShitRhythmItem;
    [SerializeField] private GameObject _prefabEndLevel;
    
    [SerializeField] private List<GameObject> _rhythmItemSpawnPoints;

    [SerializeField] private int _shitRhythmItemProbability = 10;
    [SerializeField] private int _catRhythmItemProbability = 10;

    private float _spawnTimer = 0.0f;
    
    private bool _shouldSpawnItems = true;

    private RhythmItemsSegment[] _segments = new RhythmItemsSegment[]
    {
        new FullFoodTestRhythmItemsSegment(), 
        new EndLevelRhythmItemsSegment()
    };

    private int _currentSegmentIndex = -1;

    private void ActivateNextSegment()
    {
        _currentSegmentIndex++;

        if (_currentSegmentIndex < _segments.Length)
        {
            var segment = _segments[_currentSegmentIndex];

            switch (segment.GetSpeedType())
            {
                case SpeedType.SLOW:
                    GlobalGameplaySettingsComponent.Instance.SetSlowSpeed();
                    break;
                case SpeedType.NORMAL:
                    GlobalGameplaySettingsComponent.Instance.SetNormalSpeed();
                    break;
                case SpeedType.FAST:
                    GlobalGameplaySettingsComponent.Instance.SetFastSpeed();
                    break;
            }
        }
    }
    
    private void Start()
    {
        ActivateNextSegment();
    }

    private void Update()
    {
        if (_currentSegmentIndex < _segments.Length)
        {
            _spawnTimer += Time.deltaTime;
            
            var segment = _segments[_currentSegmentIndex];
            
            if (_spawnTimer >= segment.GetSpawnTime())
            {
                _spawnTimer = 0.0f;

                SpawnRhythmItem();
            }
        }
    }

    private void SpawnRhythmItem()
    {
        var segment = _segments[_currentSegmentIndex];

        var rhythmData = segment.GetNextItem();

        for (int i = 0; i < 4; i++)
        {
            switch (rhythmData.type[i])
            {
                case RhythmItemType.NOTHING:
                    // Empty place.
                    break;
                case RhythmItemType.FOOD:
                    SpawnFood(i);
                    break;
                case RhythmItemType.FAKE:
                    SpawnFake(i);
                    break;
                case RhythmItemType.GRANDMA:
                    SpawnGrandma(i);
                    break;
                case RhythmItemType.LEVELEND:
                    SpawnLevelEnd(i);
                    break;
            }
        }

        if (!segment.HasNextItem())
        {
            ActivateNextSegment();
        }

        // bool shouldDisplayShitItem = Random.Range(0, _shitRhythmItemProbability) == 9;
        //
        // if (shouldDisplayShitItem)
        // {
        //     int spawnPointIndex = Random.Range(0, _rhythmItemSpawnPoints.Count);
        //     Vector3 spawnPointPosition = _rhythmItemSpawnPoints[spawnPointIndex].transform.position;
        //
        //     Instantiate(_prefabShitRhythmItem, spawnPointPosition, _prefabShitRhythmItem.transform.rotation);
        // } 
        // else
        // {
        //     int spawnPointIndex = Random.Range(0, _rhythmItemSpawnPoints.Count);
        //     Vector3 spawnPointPosition = _rhythmItemSpawnPoints[spawnPointIndex].transform.position;
        //     
        //     var gameObject = Instantiate(_prefabRhythmItem, spawnPointPosition, _prefabRhythmItem.transform.rotation);
        //     var rhythmItemController = gameObject.GetComponent<RhythmItemController>();
        //     
        //     bool isFakeItem = Random.Range(0, _catRhythmItemProbability) == 3;
        //     
        //     if (isFakeItem)
        //     {
        //         rhythmItemController.SetFakeCat();
        //     }
        // }
    }

    private void SpawnFood(int spawnPointIndex)
    {
        Vector3 spawnPointPosition = _rhythmItemSpawnPoints[spawnPointIndex].transform.position;
                    
        var gameObject = Instantiate(_prefabRhythmItem, spawnPointPosition, _prefabRhythmItem.transform.rotation);
        var rhythmItemController = gameObject.GetComponent<RhythmItemController>();
    }

    private void SpawnFake(int spawnPointIndex)
    {
        Vector3 spawnPointPosition = _rhythmItemSpawnPoints[spawnPointIndex].transform.position;
                    
        var gameObject = Instantiate(_prefabRhythmItem, spawnPointPosition, _prefabRhythmItem.transform.rotation);
        var rhythmItemController = gameObject.GetComponent<RhythmItemController>();
        
        rhythmItemController.SetFakeCat();        
    }

    private void SpawnGrandma(int spawnPointIndex)
    {
        Vector3 spawnPointPosition = _rhythmItemSpawnPoints[spawnPointIndex].transform.position;
                    
        Instantiate(_prefabShitRhythmItem, spawnPointPosition, _prefabShitRhythmItem.transform.rotation); 
    }

    private void SpawnLevelEnd(int spawnPointIndex)
    {
        Instantiate(_prefabEndLevel, _rhythmItemSpawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
    }
}
