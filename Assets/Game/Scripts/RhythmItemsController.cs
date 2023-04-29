using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RhythmItemsController : MonoBehaviour
{
    [SerializeField] private GameObject _prefabRhythmItem;
    [SerializeField] private GameObject _prefabShitRhythmItem;
    
    [SerializeField] private List<GameObject> _rhythmItemSpawnPoints;

    [SerializeField] private int _shitRhythmItemProbability = 10;

    private float _spawnTime = 1.0f;
    
    private float _spawnTimer = 0.0f;
    
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
        bool shouldDisplayShitItem = Random.Range(0, _shitRhythmItemProbability) == 9;
        
        if (shouldDisplayShitItem)
        {
            int spawnPointIndex = Random.Range(0, _rhythmItemSpawnPoints.Count);
            Vector3 spawnPointPosition = _rhythmItemSpawnPoints[spawnPointIndex].transform.position;
        
            GameObject shitRhythmItem = Instantiate(_prefabShitRhythmItem, spawnPointPosition, Quaternion.identity);
        } 
        else
        {
            int spawnPointIndex = Random.Range(0, _rhythmItemSpawnPoints.Count);
            Vector3 spawnPointPosition = _rhythmItemSpawnPoints[spawnPointIndex].transform.position;
        
            GameObject rhythmItem = Instantiate(_prefabRhythmItem, spawnPointPosition, Quaternion.identity);
        }

    }
}
