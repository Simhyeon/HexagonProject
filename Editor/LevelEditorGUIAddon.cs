using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelEditor))]
public class LevelEditorGUIAddon : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelEditor myScript = (LevelEditor)target;
        //if(GUILayout.Button("Switch Grid"))
        //{
        //    myScript.SwitchGrid();
        //}
        GUILayout.Label(myScript.DisplayCoord());
        if (GUILayout.Button("Move Up"))
        {
            myScript.MovePointerUp();
        }
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Move Left"))
        {
            myScript.MovePointerLeft();
        }
        if (GUILayout.Button("Move Right"))
        {
            myScript.MovePointerRight();
        }
        GUILayout.EndHorizontal();
        if (GUILayout.Button("Move Down"))
        {
            myScript.MovePointerDown();
        }

        if(GUILayout.Button("Reset Pointer"))
        {
            myScript.ResetPointer();
        }

        if (GUILayout.Button("Draw Grid"))
        {
            myScript.DrawGrids();
        }
        //GUILayout.Space(10f);
        //if(GUILayout.Button("Update Grid"))
        //{
        //    myScript.UpdateGrid();
        //}
    }
}
