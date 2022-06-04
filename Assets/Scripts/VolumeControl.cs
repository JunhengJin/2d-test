using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider voiceSlider;

    public bool playMusic = false;
    // Start is called before the first frame update
    void Start()
    {
        voiceSlider.value = AudioManager.GetMusicAudioVolume();
        if (playMusic == true)
        {
            AudioManager.PlayTitleMusicAudio();
        }
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.ChangeMusicAudioVolume(voiceSlider.value);
    }
}
