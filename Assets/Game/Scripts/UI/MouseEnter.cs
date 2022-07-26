using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MouseEnter : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject Target;
    public Slider TargetSlider1;
    public Slider TargetSlider2;
    public Slider TargetSlider3;
    public bool showBuff = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Target.SetActive(true);
        if (showBuff == false)
        {
            TextManager.ShowData("<color=#4169E1>Water: </color>"+TargetSlider1.value/TargetSlider1.maxValue*100+"<color=#4169E1>%</color>\n"
                                 +"<color=#d81300>Health: </color>"+TargetSlider2.value/TargetSlider2.maxValue*100+"<color=#d81300>%</color>\n"
                                 +"<color=#feae34>Hunger: </color>"+TargetSlider3.value/TargetSlider3.maxValue*100+"<color=#feae34>%</color>");
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Target.SetActive(false);
    }
}
