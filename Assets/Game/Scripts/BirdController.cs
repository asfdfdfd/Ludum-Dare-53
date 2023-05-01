using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _lanes;

    [FormerlySerializedAs("_rhythmItemPickupSound")] [SerializeField] private AudioSource _rhythmItemPickupAudioSource;
    [SerializeField] private AudioSource _shitRhythmItemPickupAudioSource;

    [SerializeField] private GameObject _prefabPopUpText;

    [SerializeField] private MusicPlayerComponent _musicPlayer;

    [SerializeField] private GameObject _srenkInTheMiddle;
    [SerializeField] private Image _srenkInTheMiddleImage;

    [SerializeField] private GameObject _prefabPook;
    [SerializeField] private GameObject _prefabBabkaSrenk;
    
    public UnityEvent levelEndEvent;

    private int _currentLaneIndex = -1;

    private bool _isSrenkDisplayed = false;
    
    public void MoveToStartupLane()
    {
        MoveToLane(2);
    }

    private void MoveToLane(int index)
    {
        _currentLaneIndex = index;
        
        transform.position = _lanes[index].transform.position;
    }

    private void MoveLeft()
    {
        _currentLaneIndex--;
        
        if (_currentLaneIndex < 0)
        {
            _currentLaneIndex = 0;
        }
        
        MoveToLane(_currentLaneIndex);
    }

    private void MoveRight()
    {
        _currentLaneIndex++;
        
        if (_currentLaneIndex == _lanes.Count)
        {
            _currentLaneIndex = _lanes.Count - 1;
        }
        
        MoveToLane(_currentLaneIndex);
    }

    private void Update()
    {
        if (!GameState.ShouldStartGameplayRightNow)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        } 
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        GameObject otherGameObject = other.gameObject;
        
        RhythmItemController rhythmItemController = otherGameObject.GetComponent<RhythmItemController>();
        if (rhythmItemController != null)
        {
            GameObject gameObjectText = Instantiate(_prefabPopUpText, otherGameObject.transform.position, _prefabPopUpText.transform.rotation);
            PopUpTextController controller = gameObjectText.GetComponent<PopUpTextController>();
            controller.SetText(String.Format("+{0}", GlobalGameplaySettingsComponent.Instance.PointsPerOneRhythmItem));
            
            GameState.PointsCollected += GlobalGameplaySettingsComponent.Instance.PointsPerOneRhythmItem;
            if (GameState.PointsCollected > GlobalGameplaySettingsComponent.Instance.PointsPerLevel)
            {
                GameState.PointsCollected = GlobalGameplaySettingsComponent.Instance.PointsPerLevel;
            }
            
            _rhythmItemPickupAudioSource.Play();
            Destroy(otherGameObject);
            
            Instantiate(_prefabPook, gameObject.transform.position, _prefabPook.transform.rotation);

            return;
        }
        
        ShitRhythmItemController shitRhythmItemController = otherGameObject.GetComponent<ShitRhythmItemController>();
        if (shitRhythmItemController != null)
        {
            GameObject gameObjectText = Instantiate(_prefabPopUpText, otherGameObject.transform.position, _prefabPopUpText.transform.rotation);
            PopUpTextController controller = gameObjectText.GetComponent<PopUpTextController>();
            controller.SetText(String.Format("-{0}", GlobalGameplaySettingsComponent.Instance.PointsPerOneShitItem));
            
            GameState.PointsCollected -= GlobalGameplaySettingsComponent.Instance.PointsPerOneShitItem;
            if (GameState.PointsCollected <= 0)
            {
                GameState.PointsCollected = 0;
            }
            
            _shitRhythmItemPickupAudioSource.Play();
            Destroy(otherGameObject);

            StartCoroutine(ShowSrenk());

            Instantiate(_prefabBabkaSrenk, gameObject.transform.position, _prefabBabkaSrenk.transform.rotation);
            
            return;
        }

        CatRhythmItemController catRhythmItemController = otherGameObject.GetComponent<CatRhythmItemController>();
        if (catRhythmItemController != null)
        {
            SceneManager.LoadScene("DeathFromCatScene");
            return;
        }
        
        EndLevelRhythmItemController endLevelRhythmItemController = otherGameObject.GetComponent<EndLevelRhythmItemController>();
        if (endLevelRhythmItemController != null)
        {
            Destroy(otherGameObject);
            levelEndEvent?.Invoke();

            return;
        }       
        
        StartSegmentRhytmItemController startSegmentRhytmItemController = otherGameObject.GetComponent<StartSegmentRhytmItemController>();
        if (startSegmentRhytmItemController != null)
        {
            var segment = startSegmentRhytmItemController.Segment;
            
            switch (segment.GetSpeedType())
            {
                case SpeedType.SLOW:
                    GlobalGameplaySettingsComponent.Instance.SetSlowSpeed();
                    break;
                case SpeedType.NORMAL:
                    GlobalGameplaySettingsComponent.Instance.SetNormalSpeed();
                    break;
                case SpeedType.FAST:
                    GlobalGameplaySettingsComponent.Instance.SetFastSpeed();
                    break;
            }
            
            _musicPlayer.PlayMusic(segment.GetSpeedType());

            Destroy(otherGameObject);
            
            return;
        }          
    }

    private IEnumerator ShowSrenk()
    {
        if (!_isSrenkDisplayed)
        {
            _isSrenkDisplayed = true;

            _srenkInTheMiddle.SetActive(true);
            
            yield return _srenkInTheMiddleImage.DOFade(1.0f, 0.3f).From(0.0f).WaitForCompletion();
            yield return new WaitForSeconds(0.3f);
            yield return _srenkInTheMiddleImage.DOFade(0.0f, 0.3f).From(1.0f).WaitForCompletion();

            _isSrenkDisplayed = false;
        }
    } 
}
