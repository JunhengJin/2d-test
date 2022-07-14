using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueControlor : MonoBehaviour
{
    //public GameObject Player;
    public List<Slider> TargetSlider = new List<Slider>();
    public List<float> TargetValue = new List<float>();
    public List<Sprite> Target_sprite = new List<Sprite>();
    public GameObject Target;
    public float delaytime = 0f;
    bool isable = false;
    bool LeakWater = false;
    bool DontHaveWater = false;
    int count = 0;
    GameObject Smoke;
    private Animator myAnim;

    public enum ValueControl
    {
        food,water,washHand,cleanCar,washBody,
    }

    public ValueControl valueControl;
    // Start is called before the first frame update
    void Start()
    {
        if (valueControl == ValueControl.washHand||valueControl == ValueControl.washBody)
        {
            myAnim = GetComponent<Animator>();
        }
        if (valueControl == ValueControl.cleanCar)
        {
            Smoke = GameObject.FindWithTag("Smoke");
            Smoke.SetActive(false);
        }
        if (valueControl == ValueControl.washBody)
        {
            Target.SetActive(false);
        }
        //Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(valueControl== ValueControl.food)
        {
            if (isable == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ValueManager.InstantChangeValue("F", TargetValue[0]);
                    TextManager.ShowText("");
                    AudioManager.PlayEatingAudio();
                    Destroy(Target);
                }
            }
        }

        if (valueControl == ValueControl.water)
        {
            if (isable == true)
            {
                if (TargetSlider[0].value <= 500 && count == 0)
                {
                    TextManager.ShowText("Don't have enough water!");
                }else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (count == 0)
                        {
                            TextManager.ShowText("Doing...");
                            count++;
                            Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[1];
                            ValueManager.InstantChangeValue("H", TargetValue[1]);
                            Invoke("GoTolietPart", 1f);
                        }
                        else if (count == 2)
                        {
                            count++;
                            TextManager.ShowText("Flushing...");
                            Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[2];
                            Invoke("FlushingPart", delaytime);
                            TopDownCharacterController.ChangeBool(false);
                            ValueManager.GradualChangeValue("W", TargetValue[0], delaytime);
                            AudioManager.PlayFlushingAudio();
                        }
                    }
                }
                
            }
        }

        if (valueControl == ValueControl.washHand)
        {
            if (isable == true)
            {
                if (TargetSlider[0].value <= 500&&count==0)
                {
                    TextManager.ShowText("Don't have enough water!");
                }
                else
                {
                    DontHaveWater = false;
                    if (TargetSlider[0].value <= 1)
                    {
                        DontHaveWater = true;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (count == 0)
                        {
                            AudioManager.PlayOpenTapAudio();
                            count++;
                            TextManager.ShowText("Waiting...");
                            myAnim.SetBool("canTurnon", true);
                            myAnim.SetBool("isFulled", false);
                            myAnim.SetBool("CanDrain", false);
                            myAnim.SetBool("Fturnoff", false);
                            LeakWater = true;
                            Invoke("WatiTurnOff", 1.1f);
                        }
                        else if (count == 2)
                        {
                            AudioManager.PlayCloseTapAudio();
                            myAnim.SetBool("Fturnoff", true);
                            count++;
                            LeakWater = false;
                            myAnim.SetBool("canTurnon", false);
                            myAnim.SetBool("isFulled", false);
                            myAnim.SetBool("CanDrain", false);
                            TextManager.ShowText("Press 'E' to Wash Hand");
                        }
                        else if (count == 3)
                        {
                            count++;
                            AudioManager.PlayWashingHandAudio();
                            ValueManager.GradualChangeValue("H", TargetValue[0], delaytime);
                            TextManager.ShowText("Washing...");
                            Invoke("DrainOffWater", delaytime);
                            TopDownCharacterController.ChangeBool(false);
                        }
                        else if (count == 5)
                        {
                            AudioManager.PlayDrainWaterAudio();
                            count++;
                            myAnim.SetBool("canTurnon", false);
                            myAnim.SetBool("isFulled", false);
                            myAnim.SetBool("CanDrain", true);
                            myAnim.SetBool("Fturnoff", false);
                            TextManager.ShowText("Draining...");
                            Invoke("TapGoBack", 1f);
                        }
                        if(count == 7)
                        {
                            count = 4;
                            AudioManager.PlayWashingHandAudio();
                            TextManager.ShowText("Washing...");
                            Invoke("DrainOffWater", delaytime);
                            TopDownCharacterController.ChangeBool(false);
                            ValueManager.GradualChangeValue("W", TargetValue[1], delaytime);
                        }
                    }
                    if (DontHaveWater == true&&count ==2)
                    {
                        myAnim.SetBool("Fturnoff", true);
                        AudioManager.PauseInteractiveAudio();
                        LeakWater = false;
                        myAnim.SetBool("canTurnon", false);
                        myAnim.SetBool("isFulled", false);
                        myAnim.SetBool("CanDrain", false);
                        TextManager.ShowText("Don't have enough water, Put 'E' to Wash Hand");
                        count = 7;
                    }
                    if(count == 4)
                    {
                        //ValueManager.GradualChangeValue("H", TargetValue[1], delaytime);
                    }
                }
            }
                
            if (LeakWater == true)
            {
                ValueManager.InstantChangeValue("W", -2);
            }
        }

        if (valueControl == ValueControl.cleanCar)
        {
            if (isable == true)
            {
                if (TargetSlider[0].value <= 2000 && count == 0)
                {
                    TextManager.ShowText("Don't have enough water!");
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (count == 0)
                        {
                            TextManager.ShowText("Doing...");
                            TopDownCharacterController.ChangeBool(false);
                            ValueManager.GradualChangeValue("W", TargetValue[0], delaytime);
                            count++;
                            Smoke.transform.position = this.transform.position;
                            Smoke.SetActive(true);
                            AudioManager.PlayCleanCarAudio();
                            Invoke("CleanCar", delaytime);
                        }
                    }
                }

            }
        }
        
        if (valueControl == ValueControl.washBody)
        {
            if (isable == true)
            {
                if (TargetSlider[0].value <= 500&&count==0)
                {
                    TextManager.ShowText("Don't have enough water!");
                }
                else
                {
                    DontHaveWater = false;
                    if (TargetSlider[0].value <= 1)
                    {
                        DontHaveWater = true;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (count == 0)
                        {
                            AudioManager.PlayOpenTapAudio();
                            count++;
                            TextManager.ShowText("Waitting...");
                            myAnim.SetBool("IsOffed", true);
                            myAnim.SetBool("IsLooped", false);
                            LeakWater = true;
                            Invoke("CanWashBody", 1.1f);
                        }
                        else if (count == 2)
                        {
                            count++;
                            TextManager.ShowText("Bathing...");
                            TopDownCharacterController.ChangeBool(false);
                            ValueManager.GradualChangeValue("H", TargetValue[0], delaytime);
                            Target.transform.position = this.transform.position;
                            Target.SetActive(true);
                            AudioManager.PlayCleanCarAudio();
                            Invoke("FinishBathing", delaytime);
                        }
                        else if (count == 4)
                        {
                            count++;
                            AudioManager.PlayDrainWaterAudio();
                            LeakWater = false;
                            TextManager.ShowText("Closing...");
                            myAnim.SetBool("IsOffed", false);
                            myAnim.SetBool("IsLooped", true);
                            TopDownCharacterController.ChangeBool(false);
                            Invoke("WashBodyGoBack", 1.1f);
                        }
                    }
                    if (DontHaveWater == true&&count ==3)
                    {
                        AudioManager.PauseInteractiveAudio();
                        AudioManager.PlayDrainWaterAudio();
                        LeakWater = false;
                        myAnim.SetBool("IsOffed", false);
                        myAnim.SetBool("IsLooped", true);
                        TextManager.ShowText("Don't have enough water!");
                        count = 0;
                    }
                }
            }
                
            if (LeakWater == true)
            {
                ValueManager.InstantChangeValue("W", -2);
            }
        }

    }
    //GoToliet
    void GoTolietPart()
    {
        TextManager.ShowText("Put 'E' to flush the toilet");
        count++;
    }
    void FlushingPart()
    {
        TextManager.ShowText("Put 'E' go to the toilet");
        TopDownCharacterController.ChangeBool(true);
        Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[0];
        count = 0;
    }
    //WashHand
    void WatiTurnOff()
    {
        AudioManager.PauseInteractiveAudio();
        AudioManager.PlayFlowingAudio();
        count++;
        TextManager.ShowText("Put 'E' to Turn off");
        myAnim.SetBool("canTurnon", false);
        myAnim.SetBool("isFulled", true);
        myAnim.SetBool("CanDrain", false);
        myAnim.SetBool("Fturnoff", false);
    }

    void CanWashBody()
    {
        AudioManager.PauseInteractiveAudio();
        AudioManager.PlayFlowingAudio();
        count++;
        TextManager.ShowText("Put 'E' to Have a Bath");
    }
    void DrainOffWater()
    {
        TextManager.ShowText("Put 'E' to drain off water");
        TopDownCharacterController.ChangeBool(true);
        count++;
    }

    void WashBodyGoBack()
    {
        TopDownCharacterController.ChangeBool(true);
        TextManager.ShowText("Put 'E' to turn on the switch");
        count = 0;
        AudioManager.PauseInteractiveAudio();
    }
    void TapGoBack()
    {
        myAnim.SetBool("canTurnon", false);
        myAnim.SetBool("isFulled", false);
        myAnim.SetBool("CanDrain", false);
        myAnim.SetBool("Fturnoff", false);
        TextManager.ShowText("Put 'E' to Turn on the Tap");
        count = 0;
    }

    void CleanCar()
    {
        count++;
        Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[1];
        TopDownCharacterController.ChangeBool(true);
        Smoke.SetActive(false);
        TextManager.ShowText("No need to be cleaned");
        AudioManager.PauseInteractiveAudio();
    }

    void FinishBathing()
    {
        count++;
        TopDownCharacterController.ChangeBool(true);
        Target.SetActive(false);
        TextManager.ShowText("It has been washed enough. Press 'E' to turn off the switch");
        AudioManager.PauseInteractiveAudio();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isable = true;
            if (valueControl == ValueControl.food)
            {
                TextManager.ShowText("Put 'E' to eat");
            }
            if (valueControl == ValueControl.water)
            {
                if (count == 0)
                {
                    TextManager.ShowText("Press 'E' to Go To The Toliet");
                }
                if (count == 1)
                {
                    TextManager.ShowText("Doing...");
                }
                if (count == 2)
                {
                    TextManager.ShowText("Put 'E' to flush the toilet");
                }
                if (count == 3)
                {
                    TextManager.ShowText("Flushing...");
                }

            }
            if (valueControl == ValueControl.washHand)
            {
                if(count == 0)
                {
                    TextManager.ShowText("Put 'E' to Turn on the Tap");
                }
                if (count == 1)
                {
                    TextManager.ShowText("Waitting...");
                }
                if (count == 2)
                {
                    TextManager.ShowText("Put 'E' to Turn off");
                }
                if (count == 3)
                {
                    TextManager.ShowText("Put 'E' to Wash Hand");
                }
                if (count == 4)
                {
                    TextManager.ShowText("Washing...");
                }
                if (count == 5)
                {
                    TextManager.ShowText("Put 'E' to drain off water");
                }
                if (count == 6)
                {
                    TextManager.ShowText("Draining...");
                }
                if (count == 7)
                {
                    TextManager.ShowText("Don't have enough water, Put 'E' to Wash Hand");
                }

            }
            if (valueControl == ValueControl.cleanCar)
            {
                if (count == 0)
                {
                    TextManager.ShowText("Put 'E' Clean The Car");
                }
                if (count == 1)
                {
                    TextManager.ShowText("Doing...");
                }
                if (count == 2)
                {
                    TextManager.ShowText("No need to be cleaned");
                }

            }
            if (valueControl == ValueControl.washBody)
            {
                if(count == 0)
                {
                    TextManager.ShowText("Put 'E' to turn on the switch");
                }
                if (count == 1)
                {
                    TextManager.ShowText("Waitting...");
                }
                if (count == 2)
                {
                    TextManager.ShowText("Put 'E' to Have a Bath");
                }
                if (count == 3)
                {
                    TextManager.ShowText("Bathing...");
                }
                if (count == 4)
                {
                    TextManager.ShowText("It has been washed enough. Press 'E' to turn off the switch");
                }
                if (count == 5)
                {
                    TextManager.ShowText("Closing...");
                }
                if (count == 7)
                {
                    TextManager.ShowText("Don't have enough water!");
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TextManager.ShowText("");
            isable = false;
        }
    }
}
