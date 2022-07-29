using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMissionUi : MonoBehaviour
{
    private static ControlMissionUi current;
    public GameObject missionList;
    public List<GameObject> mission = new List<GameObject>();

    private bool showContent=false;
    private int task3Num = 0;
    private int task4Num = 0;
    private int task5Num = 0;
    private int task6Num = 0;
    private int task7Num = 0;
    
    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        current.mission[6].SetActive(false);
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
    public static void ConTask1(int Day)
    {
        string num = Day.ToString();
        current.mission[0].GetComponent<Text>().text = "1. Survive ten days under the drought.("+num+"/10)";
    }
    public static void ConTask2(bool isRead)
    {
        if (isRead)
        {
            current.mission[1].GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f, 1);
            current.mission[1].GetComponent<Text>().text = "2.Read the Survival Guide.(1/1)";
        }
    }
    public static void ConTask3(string name)
    {
        
        if (name=="Hand"||name=="Body"||name=="Toliet")
        {
            current.task3Num++;
            if(current.task3Num==3){current.mission[2].GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f, 1);}
        }
        current.mission[2].GetComponent<Text>().text = "3. Use toilet equipment. ("+current.task3Num+"/3)";
    }
    public static void ConTask4()
    {
        current.task4Num++;
        current.mission[3].GetComponent<Text>().text = "4. Find ingredients in the kitchen area.("+current.task4Num+"/2)";
        if(current.task4Num==2){current.mission[3].GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f, 1);}
    }
    public static void ConTask5()
    {
        current.task5Num++;
        current.mission[4].GetComponent<Text>().text = "5. Use ingredients to make a meal.("+current.task5Num+"/1)";
        current.mission[4].GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f, 1);
    }
    public static void ConTask6()
    {
        current.task6Num++;
        current.mission[5].GetComponent<Text>().text = "6. Wash used dishes.("+current.task6Num+"/1)";
        current.mission[5].GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f, 1);
    }
    public static void ConTask7()
    {
        current.mission[6].SetActive(true);
        current.task7Num++;
        current.mission[6].GetComponent<Text>().text = "7.Drive to collect government supplies.("+current.task7Num+"/1)";
        current.mission[6].GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f, 1);
    }
}
