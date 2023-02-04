using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CubeManager))]
public class CubeManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        CubeManager cubeManager = (CubeManager)target;

        // Show default inspector property editor
        DrawDefaultInspector();

        if (GUILayout.Button("GenerateMatrix"))
        {
            cubeManager.GenerateMatrix();
        }
    }
}
