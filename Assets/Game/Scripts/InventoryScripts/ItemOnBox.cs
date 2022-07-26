using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnBox : MonoBehaviour
{
    public List<Item> theseItem = new List<Item>();
    public Inventory playerInventory;
    private bool isable = false;
    private Animator myAnim;
    private bool Used = false;
    private bool Using = false;
    private bool firstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isable == true&&Used==false)
        {
            if (Using == false)
            {
                TextManager.ShowText("Press 'E' to pick up the items in the box");
            }
            else
            {
                TextManager.ShowText("Using");
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (firstTime == true)
                {
                    firstTime = false;
                    ControlMissionUi.ConTask4();
                }
                ValueManager.GradualChangeValue("H", 0, 5);
                myAnim.SetBool("CanOpen", true);
                myAnim.SetBool("CanClose", false);
                Using = true;
                TopDownCharacterController.ChangeBool(false);
                Invoke("CloseBox",5);
                AddNewItem();
            }
        }

        if (isable == true&&Used==true)
        {
            TextManager.ShowText("Used");
        }
    }

    public void CloseBox()
    {
        myAnim.SetBool("CanClose", true);
        myAnim.SetBool("CanOpen", false);
        TextManager.ShowText("Used");
        Used = true;
        TopDownCharacterController.ChangeBool(true);
    }
    public void AddNewItem()
    {
        for (int temp = 0; temp < theseItem.Count; temp++)
        {
            InventoryManager.AddNewItem(theseItem[temp]);
        }
    }
    
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
}
