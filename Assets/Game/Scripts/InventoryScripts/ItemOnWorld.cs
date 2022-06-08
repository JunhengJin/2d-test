using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;

    public Inventory playerInventory;

    private void OnTriggerExit2D(Collider2D other)
    {
        AddNewItem();
        Destroy(gameObject);
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add((thisItem));
            InventoryManager.CreateNewItem((thisItem));
        }
        else
        {
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }
}
