using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TopDownCharacterController : MonoBehaviour
{
    public float speed;

    private Animator animator;

    public bool isWalking = false;

    public bool canMove = true;

    public float dashForce;

    bool isDash;

    float resumeTime;

    float direction;

    public float dashTime;

    float stop = 0;

    float temp = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        temp = speed;
    }
    private void Update()
    {
        if (canMove == true)
        {
            isWalking = false;
            speed = temp;
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
                ValueManager.InstantChangeValue("F", -1);
                isWalking = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
                ValueManager.InstantChangeValue("F", -1);
                isWalking = true;
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
                ValueManager.InstantChangeValue("F", -1);
                isWalking = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
                ValueManager.InstantChangeValue("F", -1);
                isWalking = true;
            }
            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);
            GetComponent<Rigidbody2D>().velocity = speed * dir;
            if (Input.GetKeyDown(KeyCode.L) && isDash == false)
            {
                isDash = true;
                resumeTime = Time.time + dashTime;
                GetComponent<Rigidbody2D>().velocity = dir * dashForce;
            }
            if (Time.time> resumeTime)
            {
                isDash = false;
            }
        }
        else
        {
            Vector2 dir = Vector2.zero;
            dir.Normalize();
            speed = stop;
            animator.SetBool("IsMoving", false);
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
//}
