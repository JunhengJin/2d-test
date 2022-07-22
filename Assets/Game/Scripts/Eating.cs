using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    public GameObject Dishes;
    public Inventory myBag;
    public Item thisItem;
    public Item itemToBeGenerated;
    public float delaytime = 5;
    
    public bool isable = false;
    private int temp = 0;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (count == 0)
                {
                    temp = -1;
                    for (int i = 0; i < myBag.itemList.Count; i++)
                    {
                        if (myBag.itemList[i] != null)
                        {
                            if (myBag.itemList[i].itemName == thisItem.itemName)
                            {
                                temp = i;
                                break;
                            }
                        }
                    }
                    if (temp == -1)
                    {
                        count = 1;
                        TextManager.ShowText("Don't have "+thisItem.itemName);
                    }
                    else if (thisItem.itemHeld > 1)
                    {
                        count = 2;
                        thisItem.itemHeld -= 1;
                    }else
                    {
                        count = 2;
                        myBag.itemList[temp] = null;
                        InventoryManager.ClearInformation();
                    }
                    InventoryManager.RefreshItem();
                }
            }
            if (count == 2)
            {
                count = 3;
                Dishes.SetActive(true);
                TextManager.ShowText("Open the backpack to eat");
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isable = true;
            if (count == 0)
            {
                TextManager.ShowText("Press 'E' to place the plate");
            }
            if (count == 1)
            {
                TextManager.ShowText("Don't have "+thisItem.itemName);
            }
            if (count == 3)
            {
                TextManager.ShowText("press 'E' to eat");
            }

            if (count == 4)
            {
                TextManager.ShowText("eating...");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isable = false;
            TextManager.ShowText("");
            if (count == 1)
            {
                count = 0;
            }
        }
    }
}
