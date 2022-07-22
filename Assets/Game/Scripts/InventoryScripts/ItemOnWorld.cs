using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;

    public Inventory playerInventory;

    public int increaseNum = 1;
    
    private bool isable = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isable = false;
            TextManager.ShowText("");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isable = true;
        }
    }

    private void Update()
    {
        if (isable == true)
        {
            TextManager.ShowText("Press 'E' to pick up items");
            if (Input.GetKeyDown(KeyCode.E))
            {
                AddNewItem();
                Destroy(gameObject);
            }
        }
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            //playerInventory.itemList.Add((thisItem));
            //InventoryManager.CreateNewItem((thisItem));
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += increaseNum;
        }
        InventoryManager.RefreshItem();
    }
}
