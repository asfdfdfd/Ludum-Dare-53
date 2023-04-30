using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RhythmItemsController : MonoBehaviour
{
    [SerializeField] private GameObject _prefabRhythmItem;
    [SerializeField] private GameObject _prefabShitRhythmItem;
    [SerializeField] private GameObject _prefabEndLevel;
    
    [SerializeField] private List<GameObject> _rhythmItemSpawnPoints;

    [SerializeField] private int _shitRhythmItemProbability = 10;

    private float _spawnTime = 1.0f;
    
    private float _spawnTimer = 0.0f;

    private bool _shouldEndLevel = false;

    private bool _shouldSpawnItems = true;
    
    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnTime)
        {
            _spawnTimer = 0.0f;
            
            SpawnRhythmItem();
        }
    }

    private void SpawnRhythmItem()
    {
        if (!_shouldSpawnItems)
        {
            return;
        }
        
        if (_shouldEndLevel)
        {
            _shouldSpawnItems = false;
            
            Instantiate(_prefabEndLevel, _rhythmItemSpawnPoints[1].transform.position, Quaternion.identity);
            
            return;
        }
        
        bool shouldDisplayShitItem = Random.Range(0, _shitRhythmItemProbability) == 9;
        
        if (shouldDisplayShitItem)
        {
            int spawnPointIndex = Random.Range(0, _rhythmItemSpawnPoints.Count);
            Vector3 spawnPointPosition = _rhythmItemSpawnPoints[spawnPointIndex].transform.position;
        
            Instantiate(_prefabShitRhythmItem, spawnPointPosition, _prefabShitRhythmItem.transform.rotation);
        } 
        else
        {
            int spawnPointIndex = Random.Range(0, _rhythmItemSpawnPoints.Count);
            Vector3 spawnPointPosition = _rhythmItemSpawnPoints[spawnPointIndex].transform.position;
            
            Instantiate(_prefabRhythmItem, spawnPointPosition, _prefabRhythmItem.transform.rotation);
        }

    }

    public void EndLevel()
    {
        _shouldEndLevel = true;
    }
}
