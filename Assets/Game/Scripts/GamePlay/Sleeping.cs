using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Sleeping : MonoBehaviour
{
    static Sleeping current;
    public RawImage rawImage;
    public GameObject myObject;
    public float speed=0.1f;
    private float colorAlpha = 0;
    private bool isable = false;
    private bool changeCanvasPart1 = false;
    private bool changeCanvasPart2 = false;
    private bool isSleep = true;
    private bool isDoing = false;
    
    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        myObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isable==true)
        {
            TextManager.ShowText("Press 'E' to sleep");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isDoing == false)
                {
                    myObject.SetActive(true);
                    changeCanvasPart1 = true;
                    ChangeLightColor.TimeMultiple(0);
                    TopDownCharacterController.ChangeBool(false);
                    isDoing = true;
                }
                
            }
        }

        if (changeCanvasPart1 == true)
        {
            colorAlpha += Time.deltaTime*speed;
            if (colorAlpha > 1)
            {
                changeCanvasPart2 = true;
                changeCanvasPart1 = false;
                if (isSleep == true)
                {
                    ChangeLightColor.Sleep();
                }
                isSleep = true;
            }
            else
            {
                rawImage.GetComponent<RawImage>().color = new Color(0,0,0,colorAlpha);
            }
        }

        if (changeCanvasPart2 == true)
        {
            colorAlpha -= Time.deltaTime*speed;
            if (colorAlpha < 0)
            {
                changeCanvasPart2 = false;
                ChangeLightColor.TimeMultiple(-1);
                TopDownCharacterController.ChangeBool(true);
                myObject.SetActive(false);
                isDoing = false;
            }
            else
            {
                rawImage.GetComponent<RawImage>().color = new Color(0,0,0,colorAlpha);
            }
        }
    }

    public static void ChangeCanves()
    {
        ChangeLightColor.TimeMultiple(0);
        current.changeCanvasPart1 = true;
        current.isSleep = false;
        current.myObject.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isable = false;
            TextManager.ShowText("");
        }
    }
}
