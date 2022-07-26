using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackUser : MonoBehaviour
{
    private static BackpackUser instance;
    public Inventory myBag;
    private int temp;
    public Text itemInformation;
    public GameObject diningTable;
    private bool inDiningArea = false;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public static void CurrentItem(int slotID)
    {
        instance.temp = slotID;
    }
    public static void UseThisItem()
    {
        if (instance.myBag.itemList[instance.temp] != null)
        {
            instance.JudgingItems(instance.myBag.itemList[instance.temp].itemName);
            if (instance.myBag.itemList[instance.temp].itemHeld > 1)
            {
                instance.myBag.itemList[instance.temp].itemHeld -= 1;
            }
            else
            {
                instance.myBag.itemList[instance.temp].itemHeld -= 1;
                instance.myBag.itemList[instance.temp] = null;
                InventoryManager.ClearInformation();
            }
            InventoryManager.RefreshItem();
        }
    }

    public static void UseTableware(bool caneat)
    {
        instance.inDiningArea = caneat;
    }

    void JudgingItems(string itemName)
    {
        if (itemName == "FirstAidKit")
        {
            ValueManager.InstantChangeValue("H", 4000);
        }
        if (itemName == "Bacon")
        {
            AudioManager.PlayEatingAudio();
            ValueManager.InstantChangeValue("F", 4000);
            ValueManager.InstantChangeValue("H", -2000);
            if (inDiningArea == true)
            {
                ValueManager.InstantChangeValue("H", 2000);
                diningTable.GetComponent<Eating>().EatUp = true;
            }
        }
        if (itemName == "Apple"||itemName == "Watermelon")
        {
            AudioManager.PlayEatingAudio();
            ValueManager.InstantChangeValue("F", 2000);
            ValueManager.InstantChangeValue("H", -2000);
            if (inDiningArea == true)
            {
                ValueManager.InstantChangeValue("H", 4000);
                diningTable.GetComponent<Eating>().EatUp = true;
            }
        }
        if (itemName == "Chicken thigh")
        {
            AudioManager.PlayEatingAudio();
            ValueManager.InstantChangeValue("F", 4000);
            ValueManager.InstantChangeValue("H", -2000);
            if (inDiningArea == true)
            {
                ValueManager.InstantChangeValue("H", 2000);
                diningTable.GetComponent<Eating>().EatUp = true;
            }
        }
        if (itemName == "Emergency food")
        {
            AudioManager.PlayEatingAudio();
            ValueManager.InstantChangeValue("F", 7000);
            ValueManager.InstantChangeValue("H", -1000);
            if (inDiningArea == true)
            {
                ValueManager.InstantChangeValue("H", 2500);
                diningTable.GetComponent<Eating>().EatUp = true;
            }
        }
        if (itemName == "Fish")
        {
            AudioManager.PlayEatingAudio();
            ValueManager.InstantChangeValue("F", 3500);
            ValueManager.InstantChangeValue("H", -3000);
            if (inDiningArea == true)
            {
                ValueManager.InstantChangeValue("H", 2000);
                diningTable.GetComponent<Eating>().EatUp = true;
            }
        }
        if (itemName == "Fried fish fillet")
        {
            AudioManager.PlayEatingAudio();
            ValueManager.InstantChangeValue("F", 5000);
            ValueManager.InstantChangeValue("H", -1500);
            if (inDiningArea == true)
            {
                ValueManager.InstantChangeValue("H", 3500);
                diningTable.GetComponent<Eating>().EatUp = true;
            }
        }
        if (itemName == "Meatballs")
        {
            AudioManager.PlayEatingAudio();
            ValueManager.InstantChangeValue("F", 6500);
            ValueManager.InstantChangeValue("H", -2000);
            if (inDiningArea == true)
            {
                ValueManager.InstantChangeValue("H", 3000);
                diningTable.GetComponent<Eating>().EatUp = true;
            }
        }
        if (itemName == "Sushi")
        {
            AudioManager.PlayEatingAudio();
            ValueManager.InstantChangeValue("F", 4500);
            ValueManager.InstantChangeValue("H", -1500);
            if (inDiningArea == true)
            {
                ValueManager.InstantChangeValue("H", 2500);
                diningTable.GetComponent<Eating>().EatUp = true;
            }
        }
    }
}
