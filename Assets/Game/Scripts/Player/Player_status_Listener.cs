using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_status_Listener : MonoBehaviour
{
    public List<Slider> TargetSlider = new List<Slider>();
    //bool DIE = false;
    public GameObject Target;
    public GameObject HealthBuffImage;
    public GameObject HealthDebuffImage;
    public GameObject FoodBuffImage;
    public GameObject FoodDebuffImage;
    public Text Target_text;
    public int MinValue = 0;
    public float playerSpeed=5;
    public float buffSpeed = 8;
    public float debuffSpeed = 3;
    public float buffWaitTime = 1.2f;
    public float debuffWaitTime = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetSlider[0].value == MinValue)
        {
            Target.SetActive(true);
            GameObject.Find("SceneControl").GetComponent<GamePlaySceneManager>().TimeStop();
        }

        if (TargetSlider[0].value / TargetSlider[0].maxValue > 0.7)
        {
            FoodBuffImage.SetActive(true);
            TopDownCharacterController.ChangeMoveSpeed(buffSpeed);
            Debug.Log("buffSpeed: "+buffSpeed);
        }
        if (TargetSlider[0].value / TargetSlider[0].maxValue <= 0.7&&TargetSlider[0].value / TargetSlider[0].maxValue>0.25)
        {
            FoodDebuffImage.SetActive(false);
            FoodBuffImage.SetActive(false);
            TopDownCharacterController.ChangeMoveSpeed(playerSpeed);
        }
        if (TargetSlider[0].value / TargetSlider[0].maxValue <= 0.25)
        {
            FoodDebuffImage.SetActive(true);
            TopDownCharacterController.ChangeMoveSpeed(debuffSpeed);
        }
        if (TargetSlider[1].value / TargetSlider[1].maxValue > 0.7)
        {
            HealthBuffImage.SetActive(true);
            ValueManager.ChangeTimeMuliplier(buffWaitTime);
        }
        if (TargetSlider[1].value / TargetSlider[1].maxValue <= 0.7&&TargetSlider[1].value / TargetSlider[1].maxValue>0.25)
        {
            HealthDebuffImage.SetActive(false);
            HealthBuffImage.SetActive(false);
            ValueManager.ChangeTimeMuliplier(1);
        }
        if (TargetSlider[1].value / TargetSlider[1].maxValue <= 0.25)
        {
            HealthDebuffImage.SetActive(true);
            ValueManager.ChangeTimeMuliplier(debuffWaitTime);
        }
    }
}
