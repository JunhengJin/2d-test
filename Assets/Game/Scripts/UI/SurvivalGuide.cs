using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalGuide : MonoBehaviour
{
    private bool isable = false;
    private bool isFirstTime = true;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        Target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Target.SetActive(true);
                TopDownCharacterController.ChangeBool(false);
                if (isFirstTime == true)
                {
                    isFirstTime = false;
                    ControlMissionUi.ConTask2(true);
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isable = true;
        if (collision.gameObject.tag == "Player")
        {
            TextManager.ShowText("Press 'E' read the Survival Guide");
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        isable = false;
        if (collision.gameObject.tag == "Player")
        {
            TextManager.ShowText("");
        }
    }
}
