using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{

    //public List<GameObject> StartingWeapons = new List<GameObject>();
    public TopDownCharacterController Player;
    public List<AudioSource> walking = new List<AudioSource>();
    int rangenumber = 0;
    float time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (Player.iswalking == true && time < 0)
        {
            playVoice();
            time = 0.5f;
        }
    }
    void playVoice()
    {
        rangenumber = Random.Range(0, walking.Count - 1);
        walking[rangenumber].Play();
    }
}
