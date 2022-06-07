using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class GenTarget : MonoBehaviour
{
    public GameObject slotPrefab;
    GameObject[] items;
    public int slotNum = 25;

    private void Awake()
    {
        items = new GameObject[slotNum];
        for (int i = 0; i < slotNum; i++)
        {
            items[i] = transform.GetChild(i).gameObject;
            items[i].name = "slot" + i;
        }
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(GenTarget))]
public class InventoryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GenTarget genTarget = target as GenTarget;
        if (GUILayout.Button("Gen"))
        {
            var chileNum = Selection.activeTransform.childCount;
            for (int i = 0; i < chileNum; i++)
            {
                DestroyImmediate( Selection.activeTransform.GetChild(0).gameObject);
            }
            for (int i = 0; i < genTarget.slotNum; i++)
            {
                GameObject go = Instantiate(genTarget.slotPrefab, Selection.activeTransform);
            }
        }
        base.OnInspectorGUI();
    }
}
#endif