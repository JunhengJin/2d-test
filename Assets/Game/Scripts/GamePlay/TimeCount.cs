using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    int Hours = 7;
    int Mintues = 0;
    float count = 0f;
    public Text Time_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= 1)
        {
            if(Mintues < 59)
            {
                Mintues++;
            }
            else
            {
                Hours++;
                Mintues = 0;
            }
            count = 0;
        }
        if (Hours < 10)
        {
            Time_text.text = "0"+Hours + ": ";
        }
        else
        {
            Time_text.text = Hours + ": ";
        }
        if (Mintues < 10)
        {
            Time_text.text = Time_text.text +"0" + Mintues;
        }
        else
        {
            Time_text.text = Time_text.text + Mintues;
        }
    }
}
