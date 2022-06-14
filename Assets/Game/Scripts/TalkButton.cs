using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;

    public GameObject talkUI;

    private bool showUI = false;

    private void Start()
    {
        talkUI.SetActive(false);
        Button.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Button.transform.position = gameObject.transform.position+Vector3.up*2.1f;
            Button.SetActive(true);
            showUI = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Button.SetActive(false);
            showUI = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (showUI==true && Input.GetKeyDown(KeyCode.R))
        {
            talkUI.SetActive(true);
        }
    }
}
