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
    
    private List<string> textList = new List<string>();
   
    void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinsihed = true;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.R)&&textFinsihed)
        {
            //textLabel.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
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
        
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }
        textFinsihed = true;
        index++;
    }
}
