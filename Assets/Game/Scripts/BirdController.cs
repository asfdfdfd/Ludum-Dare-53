using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _lanes;

    [FormerlySerializedAs("_rhythmItemPickupSound")] [SerializeField] private AudioSource _rhythmItemPickupAudioSource;
    [SerializeField] private AudioSource _shitRhythmItemPickupAudioSource;

    [SerializeField] private GameObject _prefabPopUpText;
    
    public UnityEvent levelEndEvent;

    private int _currentLaneIndex = -1;
    
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
    }
}
