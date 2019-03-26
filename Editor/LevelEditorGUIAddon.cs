﻿using System.Collections;
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
        if (GUILayout.Button("Draw Grid"))
        {
            myScript.DrawGrids();
        }
        if (GUILayout.Button("Reset Grid"))
        {
            myScript.ResetGrids();
        }
    }
}
