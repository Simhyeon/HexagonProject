using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LevelSetter))]
public class LevelBuilder : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelSetter myScript = (LevelSetter)target;
        GUILayout.Label(myScript.coord.ToString());
        if (GUILayout.Button("Move Up"))
        {
            myScript.MoveUp();
        }
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Move Left"))
        {
            myScript.MoveLeft();
        }
        if (GUILayout.Button("Move Right"))
        {
            myScript.MoveRight();
        }
        GUILayout.EndHorizontal();
        if (GUILayout.Button("Move Down"))
        {
            myScript.MoveDown();
        }
    }
}
