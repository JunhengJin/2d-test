using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    public Text targetText;
    static TextManager _current;
    
    private void Awake()
    {
        _current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ShowText(string context)
    {
        _current.targetText.text = context;
    }
    
    
}
