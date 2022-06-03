using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGhost : MonoBehaviour
{
    public float ghostTime;
    float temp;
    GameObject target;

    SpriteRenderer sprite;
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        gameObject.GetComponent<SpriteRenderer>().sprite = target.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<SpriteRenderer>().flipX = target.GetComponent<SpriteRenderer>().flipX;
        gameObject.transform.position = target.transform.position;
        temp = ghostTime;
    }

    // Update is called once per frame
    void Update()
    {
        ghostTime -= Time.deltaTime;
        if (ghostTime >0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.2f+ghostTime*4/ temp*5, 0.2f + ghostTime * 4 / temp * 5, 0.2f + ghostTime * 4 / temp * 5, ghostTime / temp);
        }
        else { Destroy(gameObject); }
    }

}
