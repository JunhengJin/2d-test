using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueManager : MonoBehaviour
{
    static ValueManager current;
    public Slider Food_Slider;
    public Slider Health_Slider;
    public Slider Water_Slider;
    public Slider Progress_Slider;
    public GameObject Progress_Target;
    float changeTime;
    float count = 0;
    float changePerValue;
    float startTime;

    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count != 0)
        {
            startTime += Time.deltaTime;
            if(startTime< changeTime)
            {
                if(count == 1)
                {
                    Food_Slider.value += changePerValue;
                }
                if (count == 2)
                {
                    Health_Slider.value += changePerValue;
                }
                if (count == 3)
                {
                    Water_Slider.value += changePerValue;
                }

                Progress_Slider.value = startTime / changeTime;
            }
            else
            {
                count = 0;
                Progress_Target.SetActive(false);
            }
 
        }
    }

    public static void InstantChangeValue(string name,float value)
    {
        if(name== "F")
        {
            current.Food_Slider.value += value;
        }
        if (name == "H")
        {
            current.Health_Slider.value += value;
        }
        if (name == "W")
        {
            current.Water_Slider.value += value;
        }
    }
    public static void GradualChangeValue(string name, float value,float time)
    {
        current.startTime = 0;
        current.changeTime = time;
        current.changePerValue = value;
        current.Progress_Target.SetActive(true);
        if (name == "F")
        {
            current.count = 1;
        }
        if (name == "H")
        {
            current.count = 2;
        }
        if (name == "W")
        {
            current.count = 3;
        }
    }
}
