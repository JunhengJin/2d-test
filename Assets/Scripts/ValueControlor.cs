using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueControlor : MonoBehaviour
{
    public GameObject Player;
    public List<Slider> TargetSlider = new List<Slider>();
    public List<float> TargetValue = new List<float>();
    public List<Sprite> Target_sprite = new List<Sprite>();
    public List<AudioSource> Target_audio = new List<AudioSource>();
    public Text Target_text;
    public GameObject Target;
    public float delaytime = 0f;
    bool isable = false;
    bool LeakWater = false;
    bool DontHaveWater = false;
    int count = 0;
    //float counttime = 0;
    private Animator myAnim;

    public enum ValueControl
    {
        food,water,washhand
    }

    public ValueControl valueControl;
    // Start is called before the first frame update
    void Start()
    {
        if (valueControl == ValueControl.washhand)
        {
            myAnim = GetComponent<Animator>();
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
                    TargetSlider[0].value += TargetValue[0];
                    Target_text.text = "";
                    Target_audio[0].Play();
                    Destroy(Target);
                }
            }
        }

        if (valueControl == ValueControl.water)
        {
            if (isable == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (count == 0)
                    {
                        Target_text.text = "Doing...";
                        count++;
                        Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[1];
                        TargetSlider[1].value += TargetValue[1];
                        Invoke("go_toliet_part", 1f);
                    }
                    else if(count == 2)
                    {
                        count++;
                        Target_text.text = "Flushing...";
                        Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[2];
                        Invoke("flushing_part", delaytime);
                        Player.GetComponent<TopDownCharacterController>().canmove = false;
                        TargetSlider[0].value -= TargetValue[0];
                        Target_audio[0].Play();
                    }
                }
            }
        }

        if (valueControl == ValueControl.washhand)
        {
            if (isable == true)
            {
                if (TargetSlider[0].value <= 500&&count==0)
                {
                    Target_text.text = "Don't enough have water!";
                }
                else
                {
                    if (TargetSlider[0].value <= 1)
                    {
                        DontHaveWater = true;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (count == 0)
                        {
                            count++;
                            Target_text.text = "Waitting...";
                            myAnim.SetBool("canTurnon", true);
                            myAnim.SetBool("isFulled", false);
                            myAnim.SetBool("CanDrain", false);
                            myAnim.SetBool("Fturnoff", false);
                            LeakWater = true;
                            Invoke("WatiTurnOff", 1.1f);
                        }
                        else if (count == 2)
                        {
                            myAnim.SetBool("Fturnoff", true);
                            count++;
                            LeakWater = false;
                            myAnim.SetBool("canTurnon", false);
                            myAnim.SetBool("isFulled", false);
                            myAnim.SetBool("CanDrain", false);
                            Target_text.text = "Put 'E' to Wash Hand";
                        }
                        else if (count == 3)
                        {
                            count++;
                            Target_text.text = "Washing...";
                            Invoke("DrainOffWater", delaytime);
                            Player.GetComponent<TopDownCharacterController>().canmove = false;
                            TargetSlider[1].value += TargetValue[1];
                            //Target_audio[0].Play();
                        }
                        else if (count == 5)
                        {
                            count++;
                            myAnim.SetBool("canTurnon", false);
                            myAnim.SetBool("isFulled", false);
                            myAnim.SetBool("CanDrain", true);
                            myAnim.SetBool("Fturnoff", false);
                            Target_text.text = "Draining...";
                            Invoke("TapGoBack", 1f);
                        }
                        if(count == 7)
                        {
                            count = 4;
                            Target_text.text = "Washing...";
                            Invoke("DrainOffWater", delaytime);
                            Player.GetComponent<TopDownCharacterController>().canmove = false;
                            TargetSlider[1].value += TargetValue[1];
                        }
                    }
                    if (DontHaveWater == true&&count ==2)
                    {
                        myAnim.SetBool("Fturnoff", true);
                        LeakWater = false;
                        myAnim.SetBool("canTurnon", false);
                        myAnim.SetBool("isFulled", false);
                        myAnim.SetBool("CanDrain", false);
                        Target_text.text = "Don't have enough water, Put 'E' to Wash Hand";
                        count = 7;
                    }
                }
            }
                
            if (LeakWater == true)
            {
                TargetSlider[0].value -= 2;
            }
        }

    }
    //GoToliet
    void go_toliet_part()
    {
        Target_text.text = "Put 'E' to flush the toilet";
        count++;
    }
    void flushing_part()
    {
        Target_text.text = "Put 'E' go to the toilet";
        Player.GetComponent<TopDownCharacterController>().canmove = true;
        Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[0];
        count = 0;
    }
    //WashHand
    void WatiTurnOff()
    {
        count++;
        Target_text.text = "Put 'E' to Turn off";
        myAnim.SetBool("canTurnon", false);
        myAnim.SetBool("isFulled", true);
        myAnim.SetBool("CanDrain", false);
        myAnim.SetBool("Fturnoff", false);
    }
    void DrainOffWater()
    {
        Target_text.text = "Put 'E' to drain off water";
        Player.GetComponent<TopDownCharacterController>().canmove = true;
        count++;
    }
    void TapGoBack()
    {
        myAnim.SetBool("canTurnon", false);
        myAnim.SetBool("isFulled", false);
        myAnim.SetBool("CanDrain", false);
        myAnim.SetBool("Fturnoff", false);
        Target_text.text = "Put 'E' to Turn on the Tap";
        count = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isable = true;
            if (valueControl == ValueControl.food)
            {
                Target_text.text = "Put 'E' to eat";
            }
            if (valueControl == ValueControl.water)
            {
                if (count == 0)
                {
                    Target_text.text = "Put 'E' Go To The Toliet";
                }
                if (count == 1)
                {
                    Target_text.text = "Doing...";
                }
                if (count == 2)
                {
                    Target_text.text = "Put 'E' to flush the toilet";
                }
                if (count == 3)
                {
                    Target_text.text = "Flushing...";
                }

            }
            if (valueControl == ValueControl.washhand)
            {
                if(count == 0)
                {
                    Target_text.text = "Put 'E' to Turn on the Tap";
                }
                if (count == 1)
                {
                    Target_text.text = "Waitting...";
                }
                if (count == 2)
                {
                    Target_text.text = "Put 'E' to Turn off";
                }
                if (count == 3)
                {
                    Target_text.text = "Put 'E' to Wash Hand";
                }
                if (count == 4)
                {
                    Target_text.text = "Washing...";
                }
                if (count == 5)
                {
                    Target_text.text = "Put 'E' to drain off water";
                }
                if (count == 6)
                {
                    Target_text.text = "Draining...";
                }
                if (count == 7)
                {
                    Target_text.text = "Don't have enough water, Put 'E' to Wash Hand";
                }

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Target_text.text = "";
            isable = false;
        }
    }
}
