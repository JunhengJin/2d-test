using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;

    public GameObject talkUI;

    public List<GameObject> DialogList = new List<GameObject>();

    public float offset = 2.1f;

    public bool IsDialog = false;
    
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
            TextManager.ShowText("Press 'R' to watch the TV");
            Button.transform.position = gameObject.transform.position+Vector3.up*offset;
            Button.SetActive(true);
            showUI = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Button.SetActive(false);
            TextManager.ShowText("");
            showUI = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (showUI==true && Input.GetKeyDown(KeyCode.R))
        {
            talkUI.SetActive(true);
            if (IsDialog == true)
            {
                if (ChangeLightColor.GetDayNum() !=6&&ChangeLightColor.GetDayNum() <11)
                {
                    DialogList[ChangeLightColor.GetDayNum()-1].SetActive(true);
                }else 
                {
                    DialogList[5].SetActive(true);
                    ChangeLightColor.SuppliesAvailable(true);
                }
            }
            TextManager.ShowText("");
        }
    }
}
