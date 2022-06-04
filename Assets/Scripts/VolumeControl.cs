using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider voiceSlider;
    // Start is called before the first frame update
    void Start()
    {
        voiceSlider.value = AudioManager.GetMusicAudioVolume();
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.ChangeMusicAudioVolume(voiceSlider.value);
    }
}
