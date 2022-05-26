using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEngine.Experimental.Rendering.Universal
{
    public class ChangeLightColor : MonoBehaviour
    {
        public Gradient gradient;
        public float time = 10;
        private float timer = 0;


        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > time) timer = 0.0f;
            GameObject.Find("Point Light 2D").GetComponent<Light2D>().color = gradient.Evaluate(timer / time);
        }
    }

}
