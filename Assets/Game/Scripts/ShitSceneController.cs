using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShitSceneController : MonoBehaviour
{
    [SerializeField] private GameObject _bird;

    [SerializeField] private GameObject _shitEndPosition;

    [SerializeField] private GameObject _shitPrefab;

    [SerializeField] private GameObject _finalTree;

    [SerializeField] private Image _faderImage;

    [SerializeField] private GameObject _endResultPanelPrefab;

    [SerializeField] private GameObject _canvas;

    [SerializeField] private AudioSource _audioSourceSpace;
    
    private bool _allowToSkip = false;
    
    private void Start()
    {
        _faderImage.enabled = true;
        _faderImage.DOFade(0.0f, 1.0f);
        
        var birdieEndPosition = _bird.transform.position + Vector3.forward * 10000;
        
        _bird.transform.DOMove(birdieEndPosition, 10.0f).SetSpeedBased(true).SetEase(Ease.Linear);

        var gameObjectShit = Instantiate(_shitPrefab, _bird.transform.position, Quaternion.identity);
        
        var scaleFactorPoop = GameState.TreeSizeCurrent;
        if (scaleFactorPoop <= 0.4f)
        {
            scaleFactorPoop = 0.4f;
        }
        
        gameObjectShit.transform.localScale *= scaleFactorPoop;
        
        gameObjectShit.transform.DOMove(_shitEndPosition.transform.position, 5.0f).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                _finalTree.SetActive(true);
  
                var scaleFactor = GameState.TreeSizeCurrent;
                if (scaleFactor <= 0.1f)
                {
                    scaleFactor = 0.1f;
                }
                
                var endScale = _finalTree.transform.localScale * scaleFactor;
                _finalTree.transform.localScale = Vector3.zero;
                _finalTree.transform.DOScale(endScale, 1.0f).SetEase(Ease.OutBounce);
            });

        StartCoroutine(ContinueGameplayCoroutine());
    }

    private IEnumerator ContinueGameplayCoroutine()
    {
        yield return new WaitForSeconds(6.0f);

        if (GameState.TreeSizeCurrent > GameState.TreeSizeBest)
        {
            GameState.TreeSizeBest = GameState.TreeSizeCurrent;
        }
        
        Instantiate(_endResultPanelPrefab, _canvas.transform);

        _allowToSkip = true;
    }

    private void Update()
    {
        if (_allowToSkip && Input.GetKeyDown(KeyCode.Space))
        {
            _audioSourceSpace.Play();
            
            _allowToSkip = false;
            
            _faderImage.DOFade(1.0f, 1.0f).OnComplete(() =>
            {
                GameState.ResetData();
                
                SceneManager.LoadScene("GameplayScene2");
            });
        }
    }
}
