using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplaySceneController : MonoBehaviour
{
    [SerializeField] private BirdController _birdController;
    
    private void Start()
    {
        _birdController.MoveToStartupLane();
        _birdController.levelEndEvent.AddListener(() =>
        {
            GameState.TreeSizeCurrent =
                GameState.PointsCollected / (float)GlobalGameplaySettingsComponent.Instance.PointsPerLevel;
            
            SceneManager.LoadScene("ShitScene");
        });
    }
}
