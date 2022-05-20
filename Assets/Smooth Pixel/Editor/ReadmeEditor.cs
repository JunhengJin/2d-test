using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SmoothPixel {

    [CustomEditor(typeof(Readme))]
    public class ReadmeEditor : Editor {

        public override void OnInspectorGUI() {

            if (GUILayout.Button("Open Readme")) {

                Application.OpenURL("file://" + Application.dataPath + "/Smooth Pixel/Editor/Readme.html");
            }
        }
    }
}
