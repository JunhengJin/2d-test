using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TopDownCharacterController : MonoBehaviour
{
    static TopDownCharacterController _current;
    public float speed;

    private Animator animator;

    public bool isWalking = false;

    private bool canMove = true;

    public float dashForce;

    bool isDash;

    float resumeTime;

    public float dashTime;

    float temp = 0;

    public float coolDown = 5;

    float coolDownTemp;
    
    public GameObject myBag;

    private bool isOpen = false;
    private void Awake()
    {
        _current = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        myBag.SetActive(isOpen);
        temp = speed;
    }
    private void Update()
    {
        coolDownTemp -= Time.deltaTime;
        if (canMove == true)
        {
            isWalking = false;
            Vector2 dir = Vector2.zero;
            if (Input.GetKeyDown(KeyCode.O))
            {
                OpenMyBag();
            }
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
            if (Input.GetKeyDown(KeyCode.LeftShift) && isDash == false&& coolDownTemp<0)
            {
                coolDownTemp = coolDown;
                isDash = true;
                resumeTime = Time.time + dashTime;
                GhostGenerator.Generate(resumeTime,dashTime);
                speed += dashForce;
            }
            if (Time.time> resumeTime)
            {
                isDash = false;
                speed = temp;
            }
            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
        else
        {
            Vector2 dir = Vector2.zero;
            dir.Normalize();
            animator.SetBool("IsMoving", false);
            GetComponent<Rigidbody2D>().velocity = 0 * dir;
        }
        
    }

    public static void ChangeBool(bool canMove)
    {
        _current.canMove = canMove;
    }

    public void OpenMyBag()
    {
        isOpen = !isOpen;
        myBag.SetActive(isOpen);
    }
}
