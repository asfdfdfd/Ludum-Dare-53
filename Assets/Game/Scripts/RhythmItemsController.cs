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
    [SerializeField] private GameObject _prefabStartSegment;

    [SerializeField] private float _normalLengthBetweenItems;
    
    [SerializeField] private List<GameObject> _rhythmItemSpawnPoints;

    // [SerializeField] private int _shitRhythmItemProbability = 10;
    // [SerializeField] private int _catRhythmItemProbability = 10;

    private bool _shouldSpawnItems = true;

    private float _previousSpawnTravelledLength = 0.0f;

    // private RhythmItemsSegment[] _segments = new RhythmItemsSegment[]
    // {
    //     new RandomFoodSegment(false, SpeedType.NORMAL),
    //     new RandomFoodSegment(true, SpeedType.NORMAL),
    //     new CorridorsOfLife02Segment(SpeedType.NORMAL),
    //     new BabkaLovushkaDjockera(SpeedType.NORMAL),
    //     new BabkaCrissCross(SpeedType.NORMAL),
    //     new CorridorsOfLife01Segment(SpeedType.NORMAL),
    //     new RandomFoodSegment(true, SpeedType.NORMAL),
    //     new RandomFoodSegment(false, SpeedType.NORMAL),
    //     
    //     new CorridorsOfDeath01Segment(SpeedType.SLOW),
    //     
    //     new BabkaCrissCross(SpeedType.FAST),
    //     new BabkaLovushkaDjockera(SpeedType.FAST),
    //     new BabkaLovushkaDjockera(SpeedType.FAST),
    //     new BabkaLovushkaDjockera(SpeedType.FAST),
    //     new CorridorsOfLife02Segment(SpeedType.FAST),
    //     new BabkaLovushkaDjockera(SpeedType.FAST),
    //     new CorridorsOfLife01Segment(SpeedType.FAST),
    //     new BabkaCrissCross(SpeedType.FAST),
    //     new BabkaLovushkaDjockera(SpeedType.FAST),
    //     new BabkaLovushkaDjockera(SpeedType.FAST),
    //     
    //     new EndLevelRhythmItemsSegment()
    // };

    private List<RhythmItemsSegment> _segments = new List<RhythmItemsSegment>();
    
    private int _currentSegmentIndex = -1;
    
    private void Start()
    {
        GenerateSegments();
        
        if (!GameState.ShouldStartGameplayRightNow)
        {
            return;
        }
        
        ActivateNextSegment();

        _normalLengthBetweenItems = GlobalGameplaySettingsComponent.Instance.GetNormalSpeed() * 0.5f;
    }

    private void GenerateSegments()
    {
        _segments.Clear();
        
        for (int i = 0; i < 4; i++)
        {
            _segments.Add(RandomSegment(SpeedType.NORMAL));
        }

        _segments.Add(new RandomFoodSegment(false, SpeedType.NORMAL));
        _segments.Add(new CorridorsOfDeath01Segment(SpeedType.SLOW));
        _segments.Add(new RandomFoodSegment(false, SpeedType.FAST));
            
        for (int i = 0; i < 10; i++)
        {
            _segments.Add(RandomSegment(SpeedType.FAST));
        }
        
        _segments.Add(new EndLevelRhythmItemsSegment());        
    }

    private RhythmItemsSegment RandomSegment(SpeedType speedType)
    {
        var randomSegmentIndex = Random.Range(0, 6);

        switch (randomSegmentIndex)
        {
            case 0:
                return new RandomFoodSegment(false, speedType);
            case 1:
                return new RandomFoodSegment(true, speedType);     
            case 2:
                return new CorridorsOfLife01Segment(speedType);
            case 3:
                return new CorridorsOfLife02Segment(speedType);
            case 4:
                return new BabkaLovushkaDjockera(speedType);
            case 5:
                return new BabkaCrissCross(speedType);
        }
        
        return new RandomFoodSegment(false, speedType);
    }
    
    private void ActivateNextSegment()
    {
        _currentSegmentIndex++;

        if (_currentSegmentIndex < _segments.Count)
        {
            var segment = _segments[_currentSegmentIndex];

            SpawnStartSegment(0, segment);
            SpawnStartSegment(1, segment);
            SpawnStartSegment(2, segment);
            SpawnStartSegment(3, segment);
        }
    }

    private void FixedUpdate()
    {
        if (!GameState.ShouldStartGameplayRightNow)
        {
            return;
        }
        
        if (_currentSegmentIndex < _segments.Count)
        {
            _previousSpawnTravelledLength += GlobalGameplaySettingsComponent.Instance.DownSpeed * Time.fixedDeltaTime;

            if (_previousSpawnTravelledLength >= _normalLengthBetweenItems)
            {
                SpawnRhythmItem();
                
                _previousSpawnTravelledLength = 0.0f;
            }
        }
    }

    private void SpawnRhythmItem()
    {
        var segment = _segments[_currentSegmentIndex];

        var rhythmData = segment.GetNextItem();

        for (int i = 0; i < 4; i++)
        {
            switch (rhythmData.typesOnLanes[i])
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

    private void SpawnStartSegment(int spawnPointIndex, RhythmItemsSegment segment)
    {
        var gameObjectSegment = Instantiate(_prefabStartSegment, _rhythmItemSpawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
        var startSegmentController = gameObjectSegment.GetComponent<StartSegmentRhytmItemController>();
        startSegmentController.SetSegment(segment);        
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
