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
                instance.myBag.itemList[instance.temp] = null;
                instance.itemInformation.text = "";
            }
            InventoryManager.RefreshItem();
        }
    }

    void JudgingItems(string itemName)
    {
        if (itemName == "FirstAidKit")
        {
            ValueManager.InstantChangeValue("H", 4000);
        }
        if (itemName == "Bacon")
        {
            ValueManager.InstantChangeValue("F", 4000);
        }
        if (itemName == "Drumsticks")
        {
            ValueManager.InstantChangeValue("F", 4000);
        }
    }
}
