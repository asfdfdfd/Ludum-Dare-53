using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndResultPanelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultCurrent;

    [SerializeField] private TextMeshProUGUI _resultBest;

    private void Start()
    {
        _resultCurrent.SetText(String.Format("{0}%", GameState.TreeSizeCurrent * 100.0f));
        _resultBest.SetText(String.Format("{0}%", GameState.TreeSizeBest * 100.0f));
    }
}
