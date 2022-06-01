using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager current;

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
    AudioSource InteractiveSource;


    private void Awake()
    {
        current = this;
        DontDestroyOnLoad(gameObject);
        musicSource = gameObject.AddComponent<AudioSource>();
        fxSource = gameObject.AddComponent<AudioSource>();
        playerSource = gameObject.AddComponent<AudioSource>();
        InteractiveSource = gameObject.AddComponent<AudioSource>();

        PlayTitleMusicAudio();
    }

    public static void PlayTitleMusicAudio()
    {
        current.musicSource.clip = current.titleMusicClip;
        current.musicSource.loop = true;
        current.musicSource.Play();
    }

    public static void PlayPlayingBackgroundMusicAudio()
    {
        current.musicSource.clip = current.playBackgroundMusicClip;
        current.musicSource.loop = true;
        current.musicSource.Play();
    }
    public static void PausePlayingBackgroundMusicAudio()
    {
        current.musicSource.Pause();
    }

    public static void ContinuePlayingBackgroundMusicAudio()
    {
        current.musicSource.Play();
    }
    public static void PlayClickAudio()
    {
        current.fxSource.clip = current.clickClip;
        current.fxSource.Play();
    }
    public static void PlayEatingAudio()
    {
        current.playerSource.clip = current.eatingClip;
        current.playerSource.Play();
    }

    public static void PlayFootstepAudio()
    {
        int index = Random.Range(0, current.walkStepClips.Length);
        current.playerSource.clip = current.walkStepClips[index];
        current.playerSource.Play();
    }

    public static void PlayDashAudio()
    {
        current.playerSource.clip = current.dashClip;
        current.playerSource.Play();
    }

    public static void PlayFlushingAudio()
    {
        current.InteractiveSource.clip = current.flushingClip;
        current.InteractiveSource.Play();
    }

    public static void PauseInteractiveAudio()
    {
        current.InteractiveSource.Pause();
    }

    public static void PlayOpenTapAudio()
    {
        current.InteractiveSource.clip = current.openTapClip;
        current.InteractiveSource.Play();
    }

    public static void PlayFlowingAudio()
    {
        current.InteractiveSource.clip = current.flowingClip;
        current.InteractiveSource.loop = true;
        current.InteractiveSource.Play();
    }

    public static void PlayCloseTapAudio()
    {
        current.InteractiveSource.clip = current.closeTapClip;
        current.InteractiveSource.loop = false;
        current.InteractiveSource.Play();
    }
    public static void PlayWashingHandAudio()
    {
        current.InteractiveSource.clip = current.washingHandClip;
        current.InteractiveSource.Play();
    }

    public static void PlayDrainWaterAudio()
    {
        current.InteractiveSource.clip = current.drainWaterClip;
        current.InteractiveSource.Play();
    }

    public static void PlayCleanCarAudio()
    {
        current.InteractiveSource.clip = current.cleanCarClip;
        current.InteractiveSource.Play();
    }

    public static void ChangeMusicAudioVolume(float value)
    {
        current.musicSource.volume = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
