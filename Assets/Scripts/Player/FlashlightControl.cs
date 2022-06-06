using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControl : MonoBehaviour
{
    public GameObject Flashlight;
    private GameObject target;
    bool switchtool = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            switchtool = !switchtool;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Flashlight.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            Flashlight.transform.position = target.transform.position + new Vector3(-0.3f, 0.5f, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Flashlight.transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
            Flashlight.transform.position = target.transform.position + new Vector3(0.3f, 0.5f, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Flashlight.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            Flashlight.transform.position = target.transform.position + new Vector3(0, 0.5f, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Flashlight.transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            Flashlight.transform.position = target.transform.position + new Vector3(0, 0.3f, 0);
        }
        Flashlight.SetActive(switchtool);
    }
}
