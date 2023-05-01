using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitProgressBarHider : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectProgressBar;

    private void Update()
    {
        _gameObjectProgressBar.SetActive(GameState.ShouldStartGameplayRightNow);
    }
}
