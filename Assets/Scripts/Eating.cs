using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eating : MonoBehaviour
{
    public GameObject Player;
    public Slider FoodSlider;
    public GameObject food_text;
    public GameObject food;
    public float Foodvalue = 1000;
    bool caneat = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(caneat == true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                FoodSlider.value += Foodvalue;
                food_text.SetActive(false);
                Destroy(food);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            food_text.SetActive(true);
            caneat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            food_text.SetActive(false);
        }
    }
}
