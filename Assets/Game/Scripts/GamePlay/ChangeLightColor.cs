using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityEngine.Experimental.Rendering.Universal
{
    public class ChangeLightColor : MonoBehaviour
    {
        public Gradient gradient;
        private float time = 1440;
        public float multiple = 1;
        private float timer = 0;
        private float temp = 0;
        
        public int Hours = 8;
        public int Mintues = 0;
        public int Day = 1;
        private float count = 0f;
        public Text Time_text;

        static ChangeLightColor current;

        private void Awake()
        {
            current = this;
            temp = multiple;
        }

        private void Update()
        {
            count += Time.deltaTime*multiple;
            if (count >= 1)
            {
                ValueManager.InstantChangeValue("F", -1);
                ValueManager.InstantChangeValue("H", -1);
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

            if (Hours == 24)
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
            
            timer =Hours*60+Mintues;
            
            if (timer > time) timer = 0.0f;
            GameObject.Find("Point Light 2D").GetComponent<Light2D>().color = gradient.Evaluate(timer / time);
        }

        public static void Sleep()
        {
            if (current.Hours >= 0 && current.Hours < 8)
            {
                ValueManager.InstantChangeValue("H", -10000*current.Hours/8);
            }

            if (current.Hours >= 8 && current.Hours < 24)
            {
                current.Day++;
                current.Hours = 8;
                current.Mintues = 0;
            }
            else
            {
                current.Hours = 8;
                current.Mintues = 0;
            }
        }

        public static void TimeMultiple(float num)
        {
            if (num == -1)
            {
                current.multiple = current.temp;
            }
            else
            {
                current.multiple = num;   
            }
        }
    }

}
