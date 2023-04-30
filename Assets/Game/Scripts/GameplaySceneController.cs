using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplaySceneController : MonoBehaviour
{
    [SerializeField] private BirdController _birdController;

    [SerializeField] private RhythmItemsController _rhythmItemsController;
    
    [SerializeField] private float _levelLengthInSeconds = 10.0f;

    private bool _isLevelEndTimerEnabled = true;
    private float _levelEndTimer = 0.0f;
    
    private void Start()
    {
        _birdController.MoveToStartupLane();
        _birdController.levelEndEvent.AddListener(() =>
        {
            GameState.TreeSizeCurrent =
                GameState.PointsCollected / (float)GlobalGameplaySettingsComponent.Instance.PointsPerLevel;
            
            SceneManager.LoadScene("ShitScene");
        });

        StartCoroutine(AwaitLevelEnd());
    }

    private IEnumerator AwaitLevelEnd()
    {
        yield return new WaitForSeconds(_levelLengthInSeconds);
        
        _rhythmItemsController.EndLevel();
    }
}
