using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadsideSpawnerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;

    [SerializeField] private float _spawnPauseSecondsMin = 1.0f;
    [SerializeField] private float _spawnPauseSecondsMax = 5.0f;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float spawnPauseSeconds = Random.Range(_spawnPauseSecondsMin, _spawnPauseSecondsMax);
            
            yield return new WaitForSeconds(spawnPauseSeconds);

            int prefabIndex = Random.Range(0, _prefabs.Count);
            
            Instantiate(_prefabs[prefabIndex], transform.position, Quaternion.identity);
        }
    }
}
