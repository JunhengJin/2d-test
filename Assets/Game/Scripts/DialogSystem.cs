using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI")] 
    public Text textLabel;

    public Image faceImage;

    [Header("Text")] 
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("Face")] public Sprite face01, face02;

    private bool textFinsihed;
    private bool cancelTyping;
    
    private List<string> textList = new List<string>();
    public bool showFace = false;
   
    void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        textFinsihed = true;
        StartCoroutine(SetTextUI());
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        //if (Input.GetKeyDown(KeyCode.R)&&textFinsihed)
        //{
       //     StartCoroutine(SetTextUI());
        //}
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (textFinsihed&&!cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if(!textFinsihed)
            {
                cancelTyping = !cancelTyping;
            }
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinsihed = false;
        textLabel.text = "";
        
        if(showFace==true){
            switch (textList[index].Trim().ToString())
            {
                case"A":
                    faceImage.sprite = face01;
                    index++;
                    break;
                case"B":
                    faceImage.sprite = face02;
                    index++;
                    break;
            }
        }
        
        //for (int i = 0; i < textList[index].Length; i++)
       // {
        //    textLabel.text += textList[index][i];

        //    yield return new WaitForSeconds(textSpeed);
        //}
        int letter = 0;
        while (!cancelTyping&&letter<textList[index].Length-1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }

        textLabel.text = textList[index];
        cancelTyping = false;
        textFinsihed = true;
        index++;
    }
}
