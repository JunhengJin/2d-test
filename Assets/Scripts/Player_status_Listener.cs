using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_status_Listener : MonoBehaviour
{
    public List<Slider> TargetSlider = new List<Slider>();
    //bool DIE = false;
    public GameObject Target;
    public Text Target_text;
    public int MinValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetSlider[0].value == MinValue)
        {
            Target.SetActive(true);
            GameObject.Find("SceneControl").GetComponent<SceneStop>().TimeStop();
        }
    }
}
