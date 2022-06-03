using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    public GameObject target;
    public float ghostNum;
    float genGhostTime;
    float temp;
    float resumeTime;
    bool startGenGhost;
    static GhostGenerator current;
    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
        current.resumeTime = resumeTime;
        current.startGenGhost = true;
        current.genGhostTime = dashTime / current.ghostNum;
        current.temp = Time.time;
    }
}
