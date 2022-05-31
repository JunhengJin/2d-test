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
    public AudioClip clickClip;

    [Header("PlayerAudio")]
    public AudioClip[] walkStepClips;
    public AudioClip[] dashClips;
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

    float time = 0.5f;
    public TopDownCharacterController Player;

    private void Awake()
    {
        current = this;
        //DontDestroyOnLoad(gameObject);
        musicSource = gameObject.AddComponent<AudioSource>();
        fxSource = gameObject.AddComponent<AudioSource>();
        playerSource = gameObject.AddComponent<AudioSource>();
        InteractiveSource = gameObject.AddComponent<AudioSource>();
    }

    public static void PlayFootstepAudio()
    {
        int index = Random.Range(0, current.walkStepClips.Length);
        current.playerSource.clip = current.walkStepClips[index];
        current.playerSource.Play();
        Debug.Log("Playing!");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (Player.isWalking == true && time < 0)
        {
            PlayFootstepAudio();
            time = 0.5f;
        }
    }
}
