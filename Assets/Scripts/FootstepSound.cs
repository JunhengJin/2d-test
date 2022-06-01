using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{

    //public List<GameObject> StartingWeapons = new List<GameObject>();
    public TopDownCharacterController Player;
    float time = 0.5f;

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
            AudioManager.PlayFootstepAudio();
            time = 0.5f;
        }
    }
}
