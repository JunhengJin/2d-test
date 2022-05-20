using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain_Sound_By_Distance : MonoBehaviour
{

    //public List<GameObject> StartingWeapons = new List<GameObject>();
    public TopDownCharacterController Player;
    public List<AudioSource> walking = new List<AudioSource>();
    int rangenumber = 0;
    bool footstepisplaying = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rangenumber = Random.Range(0, walking.Count);
        if (Player.iswalking == true)
        {
            for(int a = 0;a<= rangenumber; a++)
            {
                if (walking[a].isPlaying == true)
                {
                    footstepisplaying = true;
                    break;
                }
                else
                {
                    footstepisplaying = false;
                }
            }
            if(footstepisplaying == false)
            {
                walking[rangenumber].Play();
                Debug.Log("now is playing: " + rangenumber);
            }
            Player.iswalking = false;
        }
    }
}
