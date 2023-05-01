using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;

public class MusicPlayerComponent : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClipTrack100Music;
    [SerializeField] private AudioClip _audioClipTrack100Rhythm;
    
    [SerializeField] private AudioClip _audioClipTrack120Music;
    [SerializeField] private AudioClip _audioClipTrack120Rhythm;
    
    [SerializeField] private AudioClip _audioClipTrack140Music;
    [SerializeField] private AudioClip _audioClipTrack140Rhythm;
    
    [SerializeField] private AudioClip _audioClipTransiion100To120Music;
    [SerializeField] private AudioClip _audioClipTransiion120To100Music;
    [SerializeField] private AudioClip _audioClipTransiion120To140Music;
    [SerializeField] private AudioClip _audioClipTransiion140To120Music;
    
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceRhythm;

    [SerializeField] private AudioSource _audioSourceRhythmLost;
    
    private SpeedType _currentSpeedType;

    private void Start()
    {
        PlayMusicForce(GlobalGameplaySettingsComponent.Instance.GetSpeedType());
    }

    public void PlayMusic(SpeedType speedType)
    {
        if (_currentSpeedType != speedType)
        {
            PlayMusicForce(speedType);
        }
    }

    private void PlayMusicForce(SpeedType speedType)
    {
        _currentSpeedType = speedType;

        switch (speedType)
        {
            case SpeedType.SLOW:
                _audioSourceMusic.clip = _audioClipTrack100Music;
                _audioSourceMusic.loop = true;

                _audioSourceRhythm.clip = _audioClipTrack100Rhythm;
                _audioSourceRhythm.loop = true;
                break;
            case SpeedType.NORMAL:
                _audioSourceMusic.clip = _audioClipTrack120Music;
                _audioSourceMusic.loop = true;

                _audioSourceRhythm.clip = _audioClipTrack120Rhythm;
                _audioSourceRhythm.loop = true;
                break;          
            case SpeedType.FAST:
                _audioSourceMusic.clip = _audioClipTrack140Music;
                _audioSourceMusic.loop = true;

                _audioSourceRhythm.clip = _audioClipTrack140Rhythm;
                _audioSourceRhythm.loop = true;
                break;                
        }
            
        _audioSourceMusic.Play();
        _audioSourceRhythm.Play();
    }

    public void PlayRhythmLostSound()
    {
        _audioSourceRhythmLost.Play();
    }
}
