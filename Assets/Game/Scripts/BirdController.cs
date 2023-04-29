using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _lanes;

    [SerializeField] private AudioSource _rhythmItemPickupSound;
    
    public void MoveToStartupLane()
    {
        MoveToLane(2);
    }

    public void MoveToLane(int index)
    {
        transform.position = _lanes[index].transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveToLane(0);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveToLane(1);
        }  
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveToLane(2);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MoveToLane(3);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        GameObject otherGameObject = other.gameObject;
        RhythmItemController rhythmItemController = otherGameObject.GetComponent<RhythmItemController>();
        if (rhythmItemController != null)
        {
            _rhythmItemPickupSound.Play();
            Destroy(otherGameObject);
        }
    }
}
