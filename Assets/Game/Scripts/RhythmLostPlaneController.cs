using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RhythmLostPlaneController : MonoBehaviour
{
    [SerializeField] private MusicPlayerComponent _musicPlayer;

    [SerializeField] private float _silenceTime = 0.3f;

    [SerializeField] private float _fadeDuration = 0.1f;
    
    private bool _isSilencingOn = false;

    private float _startSoundVolume;

    private float _silenceTimer = 0.0f;
    private void OnCollisionEnter(Collision other)
    {
        return;
        
        // RhythmItemController rhythmItemController = other.gameObject.GetComponent<RhythmItemController>();
        // if (rhythmItemController != null)
        // {
        //     _silenceTimer = 0.0f;
        //     if (!_isSilencingOn)
        //     {
        //         _isSilencingOn = true;
        //         StartCoroutine(SilenceCoroutine());
        //     }
        // }
    }

    // private IEnumerator SilenceCoroutine()
    // {
    //     float startSoundVolume = _audioSourceRhythm.volume;
    //     yield return _audioSourceRhythm.DOFade(0.0f, _fadeDuration).AsyncWaitForCompletion();
    //     while (_silenceTimer < _silenceTime)
    //     {
    //         _silenceTimer += Time.deltaTime;
    //         yield return null;
    //     }
    //
    //     yield return _audioSourceRhythm.DOFade(startSoundVolume, _fadeDuration).AsyncWaitForCompletion();
    //     _isSilencingOn = false;
    // }
}
