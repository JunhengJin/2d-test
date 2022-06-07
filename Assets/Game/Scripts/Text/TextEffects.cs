using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class TextEffects : MonoBehaviour
{
    public float textShowTime_Second = 0.2f;
    private string content = "Hello World......";

    public bool isActive = false;
    private float timeCount;
    public Text targetText;
    private int currentPos = 0;


    void Update()
    {
        StartCoroutine(StarWrite());
    }

    [ContextMenu("TestShow")]
    public float StarShow(string str)
    {
        timeCount = 0;
        isActive = true;
        content = str;
        targetText.text = "";
        return timeCount * content.Length;
    }
    public void OffShow()
    {
        isActive = false;
        timeCount = 0;
        currentPos = 0;
        targetText.text = content;
    }

    IEnumerator StarWrite()
    {
        if (!isActive) yield break;
        timeCount += Time.deltaTime;
        if (timeCount >= textShowTime_Second)
        {
            timeCount = 0;
            currentPos++;
            if (currentPos > content.Length)
            {
                OffShow();
            }
            else
            {
                targetText.text = content.Substring(0, currentPos);
            }
        }
    }
}