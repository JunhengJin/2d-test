using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TopDownCharacterController : MonoBehaviour
{
    public float speed;

    private Animator animator;

    public Slider FoodSlider;

    public bool iswalking = false;

    public bool canmove = true;

    float stop = 0;

    float temp = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        temp = speed;
    }
    private void Update()
    {
        if (canmove == true)
        {
            iswalking = false;
            speed = temp;
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
                FoodSlider.value -= 1.0f;
                iswalking = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
                FoodSlider.value -= 1.0f;
                iswalking = true;
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
                FoodSlider.value -= 1.0f;
                iswalking = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
                FoodSlider.value -= 1.0f;
                iswalking = true;
            }
            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
        else
        {
            Vector2 dir = Vector2.zero;
            dir.Normalize();
            speed = stop;
            animator.SetBool("IsMoving", dir.magnitude > 0);
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
//}
