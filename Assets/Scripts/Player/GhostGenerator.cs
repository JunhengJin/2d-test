using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    public GameObject target;
    public float ghostNum;
    public float genGhostTime;
    public float temp;
    public float resumeTime;
    private bool startGenGhost;
    static GhostGenerator _current;
    private void Awake()
    {
        _current = this;
    }
    void Update()
    {
        if (startGenGhost == true)
        {
            if (Time.time < resumeTime)
            {
                if (temp < Time.time)
                {
                    Instantiate(target, default, default, transform);
                    temp = Time.time + genGhostTime;
                }
            }
            else
            {
                startGenGhost = false;
            }
        }
    }

    public static void Generate(float resumeTime,float dashTime)
    {
        _current.resumeTime = resumeTime;
        _current.startGenGhost = true;
        _current.genGhostTime = dashTime / _current.ghostNum;
        _current.temp = Time.time;
    }
}
