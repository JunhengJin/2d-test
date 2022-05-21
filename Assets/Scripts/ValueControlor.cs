using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueControlor : MonoBehaviour
{
    public GameObject Player;
    public List<Slider> TargetSlider = new List<Slider>();
    public List<float> TargetValue = new List<float>();
    public Text Target_text;
    public GameObject Target_icon;
    public float delaytime = 0f;
    bool isable = false;
    bool isused = false;
    int count = 0;
    public AudioSource target_audio;

    public enum ValueControl
    {
        food,water
    }

    public ValueControl valueControl;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    target_audio.Play();
                    Debug.Log("playing!");
                    Destroy(Target_icon);
                }
            }
        }

        if (valueControl == ValueControl.water)
        {
            if (isable == true&& isused == false)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    Invoke("waterpart", delaytime);
                    Player.GetComponent<TopDownCharacterController>().canmove = false;
                    TargetSlider[0].value -= TargetValue[0];
                    TargetSlider[1].value += TargetValue[1];
                    target_audio.Play();
                    //Destroy(Target_icon);
                    isused = true;
                }
            }
        }

    }

    void waterpart()
    {
        Target_text.text = "Already used";
        Player.GetComponent<TopDownCharacterController>().canmove = true;
        count++;
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
                if(isused == false)
                {
                    Target_text.text = "Put 'F' go to the toilet";
                    isable = true;
                }
                else
                {
                    if (count != 0)
                    {
                        Target_text.text = "Already used";
                        isable = true;
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
