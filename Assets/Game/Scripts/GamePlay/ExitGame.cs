using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Button exitGame;
    void Start()
    {
        exitGame.onClick.AddListener(SwitchScene);
    }
    void SwitchScene()
    {

#if UNITY_EDITOR 
        //如果是在编辑器环境下
        UnityEditor.EditorApplication.isPlaying = false;
#else
     //在打包出来的环境下
    Application.Quit();
#endif

    }
}