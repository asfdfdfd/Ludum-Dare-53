using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndResultPanelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultCurrent;
    [SerializeField] private TextMeshProUGUI _resultBest;

    [SerializeField] private GameObject _gameObjectSmallPoop;
    [SerializeField] private GameObject _gameObjectBigPoop;
    
    private void Start()
    {
        _resultCurrent.SetText(String.Format("{0}%", GameState.TreeSizeCurrent * 100.0f));
        _resultBest.SetText(String.Format("{0}%", GameState.TreeSizeBest * 100.0f));

        if (GameState.TreeSizeCurrent >= 0.9f)
        {
            _gameObjectBigPoop.SetActive(true);
        }
        else
        {
            _gameObjectSmallPoop.SetActive(true);
        }
    }
}
