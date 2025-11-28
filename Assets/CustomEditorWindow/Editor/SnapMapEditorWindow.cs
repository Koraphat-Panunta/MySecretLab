using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SnapMapEditorWindow : EditorWindow
{
    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }
    void OnSceneGUI(SceneView view)
    {

    }
}
