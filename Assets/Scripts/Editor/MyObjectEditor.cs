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
        if(GUILayout.Button("���������� ����"))
        {
            obj.ChangeColor(COLOR.RED);   
        }
        if(GUILayout.Button("������� ����"))
        {
            obj.ChangeColor(COLOR.GREEN); 
        }
        if(GUILayout.Button("�Ķ������� ����"))
        {
            obj.ChangeColor(COLOR.BLUE);
        }
        if(GUILayout.Button("����"))
        {
            obj.ChangeColor(COLOR.ORIGINAL);
        }
    }
}
