using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    static AudioManager _current;

    [Header("BackGroundAudio")]
    public AudioClip titleMusicClip;
    public AudioClip playBackgroundMusicClip;

    [Header("FxAudio")]
    public AudioClip clickClip;

    [Header("PlayerAudio")]
    public AudioClip[] walkStepClips;
    public AudioClip dashClip;
    public AudioClip eatingClip;

    [Header("InteractiveAudio")]
    public AudioClip flushingClip;
    public AudioClip openTapClip;
    public AudioClip flowingClip;
    public AudioClip closeTapClip;
    public AudioClip washingHandClip;
    public AudioClip drainWaterClip;
    public AudioClip cleanCarClip;

    AudioSource musicSource;
    AudioSource fxSource;
    AudioSource playerSource;
    AudioSource interactiveSource;


    private void Awake()
    {
        _current = this;
        DontDestroyOnLoad(gameObject);
        musicSource = gameObject.AddComponent<AudioSource>();
        fxSource = gameObject.AddComponent<AudioSource>();
        playerSource = gameObject.AddComponent<AudioSource>();
        interactiveSource = gameObject.AddComponent<AudioSource>();

        PlayTitleMusicAudio();
    }

    public static void PlayTitleMusicAudio()
    {
        _current.musicSource.clip = _current.titleMusicClip;
        _current.musicSource.loop = true;
        _current.musicSource.Play();
    }

    public static void PlayPlayingBackgroundMusicAudio()
    {
        _current.musicSource.clip = _current.playBackgroundMusicClip;
        _current.musicSource.loop = true;
        _current.musicSource.Play();
    }
    public static void PausePlayingBackgroundMusicAudio()
    {
        _current.musicSource.Pause();
    }

    public static void ContinuePlayingBackgroundMusicAudio()
    {
        _current.musicSource.Play();
    }
    public static void PlayClickAudio()
    {
        _current.fxSource.clip = _current.clickClip;
        _current.fxSource.Play();
    }
    public static void PlayEatingAudio()
    {
        _current.playerSource.clip = _current.eatingClip;
        _current.playerSource.Play();
    }

    public static void PlayFootstepAudio()
    {
        int index = Random.Range(0, _current.walkStepClips.Length);
        _current.playerSource.clip = _current.walkStepClips[index];
        _current.playerSource.Play();
    }

    public static void CheckFootstepAudio()
    {
        if (_current.playerSource.isPlaying != true)
        {
            PlayFootstepAudio(); 
        }
    }

    public static void PlayDashAudio()
    {
        _current.playerSource.clip = _current.dashClip;
        _current.playerSource.Play();
    }

    public static void PlayFlushingAudio()
    {
        _current.interactiveSource.clip = _current.flushingClip;
        _current.interactiveSource.Play();
    }

    public static void PauseInteractiveAudio()
    {
        _current.interactiveSource.Pause();
    }

    public static void PlayOpenTapAudio()
    {
        _current.interactiveSource.clip = _current.openTapClip;
        _current.interactiveSource.Play();
    }

    public static void PlayFlowingAudio()
    {
        _current.interactiveSource.clip = _current.flowingClip;
        _current.interactiveSource.loop = true;
        _current.interactiveSource.Play();
    }

    public static void PlayCloseTapAudio()
    {
        _current.interactiveSource.clip = _current.closeTapClip;
        _current.interactiveSource.loop = false;
        _current.interactiveSource.Play();
    }
    public static void PlayWashingHandAudio()
    {
        _current.interactiveSource.clip = _current.washingHandClip;
        _current.interactiveSource.Play();
    }

    public static void PlayDrainWaterAudio()
    {
        _current.interactiveSource.clip = _current.drainWaterClip;
        _current.interactiveSource.Play();
    }

    public static void PlayCleanCarAudio()
    {
        _current.interactiveSource.clip = _current.cleanCarClip;
        _current.interactiveSource.Play();
    }

    public static void ChangeMusicAudioVolume(float value)
    {
        _current.musicSource.volume = value;
    }

    public static float GetMusicAudioVolume()
    {
        return _current.musicSource.volume;
    }
}
