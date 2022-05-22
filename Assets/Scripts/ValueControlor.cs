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
    bool isused = false;
    bool canflush = false;
    int count = 0;

    public enum ValueControl
    {
        food,water
    }

    public ValueControl valueControl;
    // Start is called before the first frame update
    void Start()
    {
        //Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(valueControl== ValueControl.food)
        {
            if (isable == true)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    TargetSlider[0].value += TargetValue[0];
                    Target_text.text = "";
                    Target_audio[0].Play();
                    Debug.Log("playing!");
                    Destroy(Target);
                }
            }
        }

        if (valueControl == ValueControl.water)
        {
            if (isable == true)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    if (count == 0&& isused == false)
                    {
                        Target_text.text = "Put 'F' to flush the toilet";
                        Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[1];
                        TargetSlider[1].value += TargetValue[1];
                        isused = true;
                        Invoke("go_toliet_part", 1f);
                        count++;
                    }
                    else if(canflush == true&& isused == true)
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

    }
    void go_toliet_part()
    {
        canflush = true;
    }
    void flushing_part()
    {
        Target_text.text = "Put 'F' go to the toilet";
        isused = false;
        Player.GetComponent<TopDownCharacterController>().canmove = true;
        Target.GetComponent<SpriteRenderer>().sprite = Target_sprite[0];
        count = 0;
        canflush = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (valueControl == ValueControl.food)
            {
                Target_text.text = "Put 'F' to eat";
                isable = true;
            }
            if (valueControl == ValueControl.water)
            {
                isable = true;
                if (isused == false)
                {
                    Target_text.text = "Put 'F' go to the toilet";
                }
                else
                {
                    if (count == 2 && canflush == true)
                    {
                        Target_text.text = "Flushing...";
                    }
                    if (count == 1 && canflush == true)
                    {
                        Target_text.text = "Put 'F' to flush the toilet";
                    }
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
