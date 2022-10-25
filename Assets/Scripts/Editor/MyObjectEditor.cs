using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyObject))]
public class MyObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MyObject obj = (MyObject)target;
        if(GUILayout.Button("빨간색으로 변경"))
        {
            obj.ChangeColor(COLOR.RED);   
        }
        if(GUILayout.Button("녹색으로 변경"))
        {
            obj.ChangeColor(COLOR.GREEN); 
        }
        if(GUILayout.Button("파란색으로 변경"))
        {
            obj.ChangeColor(COLOR.BLUE);
        }
        if(GUILayout.Button("복구"))
        {
            obj.ChangeColor(COLOR.ORIGINAL);
        }
    }
}
