using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    private int Hours = 8;
    private int Mintues = 0;
    private int Day = 1;
    private float count = 0f;
    public Text Time_text;
   
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

        if (Hours == 25)
        {
            Day++;
            Hours = 0;
        }
        if (Hours < 10)
        {
            Time_text.text = "Day"+Day+" 0"+Hours + ": ";
        }
        else
        {
            Time_text.text = "Day"+Day+" "+Hours + ": ";
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
