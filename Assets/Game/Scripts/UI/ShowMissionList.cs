using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMissionList : MonoBehaviour
{
    public GameObject missionList;

    public float offSet = 1;

    private Vector3 temp;
    
    public float lerpSpeed = 5.0f;
    private void OnEnable()
    {
        temp = missionList.transform.position;
        missionList.transform.position+=Vector3.right*offSet;
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.x- temp.x > 0.1)
        {
            transform.position = Vector3.Lerp(transform.position, temp, lerpSpeed);
        }
    }

    private void OnDisable()
    {
        missionList.transform.position = temp;
    }
}
