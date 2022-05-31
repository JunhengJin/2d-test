using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStop : MonoBehaviour
{
    public GameObject Player;
    public AudioSource BackgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TimeStop()
    {
        Time.timeScale = 0;
        Player.GetComponent<TopDownCharacterController>().canMove = false;
        BackgroundMusic.Pause();
    }
    public void TimeStart()
    {
        Time.timeScale = 1;
        Player.GetComponent<TopDownCharacterController>().canMove = true;
        BackgroundMusic.Play();
    }
}
