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
        GUILayout.Space(10f);
        GUILayout.Label("Confirm Status : " +  myScript.isConfirmed.ToString(), EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Draw Grid"))
        {
            myScript.DrawGrids();
        }
        if (GUILayout.Button("Reset Grid"))
        {
            myScript.ResetGrids();
        }
        if (GUILayout.Button("Confirm Map"))
        {
            myScript.ConfirmLevel();
        }
        GUILayout.EndHorizontal();
    }
}
