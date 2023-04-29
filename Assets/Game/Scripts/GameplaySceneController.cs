using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySceneController : MonoBehaviour
{
    [SerializeField] private BirdController _birdController;

    private void Start()
    {
        _birdController.MoveToStartupLane();
    }
}
