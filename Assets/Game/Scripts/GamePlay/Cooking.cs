using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cooking : MonoBehaviour
{
    public GameObject Target;
    public List<Sprite> Target_sprite = new List<Sprite>();
    public Item thisItem;
    public Item itemToBeGenerated;
    public Inventory myBag;
    public float delaytime = 5;

    private bool isable = false;
    private int count = 0;
    private int temp = 0;
    private bool firstTime = true;
    public enum CookingTools
    {
        machine1,machine2,machine3
    }

    public CookingTools cookingTools;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cookingTools== CookingTools.machine1)
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

                    if (count == 4)
                    {
                        InventoryManager.AddNewItem(itemToBeGenerated);
                        Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[0];
                        TextManager.ShowText("Press 'E' to use "+thisItem.itemName+" to make food");
                        count = 0;
                    }
                }
                if (count == 2)
                {
                    count = 3;
                    Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[1];
                    TextManager.ShowText("cooking...");
                    Invoke("generateItem",delaytime);
                    ValueManager.GradualChangeValue("F",0,delaytime);
                }
            }
        }
    }

    private void generateItem()
    {
        count = 4;
        if (firstTime == true)
        {
            firstTime = false;
            ControlMissionUi.ConTask5();
        }
        TextManager.ShowText("Press 'E' to pick up the item");
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isable = true;
            if (count == 0)
            {
                TextManager.ShowText("Press 'E' to use "+thisItem.itemName+" to make food");
            }

            if (count == 1)
            {
                TextManager.ShowText("Don't have "+thisItem.itemName);
            }

            if (count == 3)
            {
                TextManager.ShowText("cooking...");
            }
            if (count == 4)
            {
                TextManager.ShowText("Press 'E' to pick up the item");
            }
        }
    }
}
