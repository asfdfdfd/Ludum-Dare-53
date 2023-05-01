using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplaySceneController : MonoBehaviour
{
    [SerializeField] private BirdController _birdController;

    [SerializeField] private GameObject _shitScreamImage;

    [SerializeField] private AudioSource _audioSource;
    
    private void Start()
    {
        _birdController.MoveToStartupLane();
        _birdController.levelEndEvent.AddListener(() =>
        {
            GameState.TreeSizeCurrent =
                GameState.PointsCollected / (float)GlobalGameplaySettingsComponent.Instance.PointsPerLevel;

            StartCoroutine(StartShitScene());
        });
    }

    private IEnumerator StartShitScene()
    {
        _shitScreamImage.SetActive(true);
        _shitScreamImage.transform.localScale = Vector3.zero;
        _audioSource.Play();
        yield return _shitScreamImage.transform.DOScale(1.0f, 0.3f).SetEase(Ease.OutBounce).WaitForCompletion();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ShitScene");
    }
}
