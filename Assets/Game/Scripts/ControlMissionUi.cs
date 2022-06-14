using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMissionUi : MonoBehaviour
{
    public GameObject missionList;
    
    private bool showContent=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            controlShow();
        }
    }
    
    public void controlShow()
    {
        showContent = !showContent;
        if (showContent == true)
        {
            missionList.SetActive(true);
        }
        else
        {
            missionList.SetActive(false);
        }
    }
}
