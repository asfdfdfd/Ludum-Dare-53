using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplaySceneAllIScreensDisplayer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _screens;

    [SerializeField] private AudioSource _audioSourceSpace;
    
    private int _currentScreen = -1;

    private void Start()
    {
        if (!GameState.ShouldStartGameplayRightNow)
        {
            ShowNextScreen();    
        }
    }

    private void ShowNextScreen()
    {
        if (_currentScreen > -1)
        {
            _screens[_currentScreen].SetActive(false);
        }
        
        _currentScreen++;

        if (_currentScreen == _screens.Count)
        {
            GameState.ShouldStartGameplayRightNow = true;

            SceneManager.LoadScene("GameplayScene2");
            
            gameObject.SetActive(false);
        }
        else
        {
            _screens[_currentScreen].SetActive(true);
        }
    }

    private void Update()
    {
        if (GameState.ShouldStartGameplayRightNow)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _audioSourceSpace.Play();
            
            ShowNextScreen();
        }
    }
}
