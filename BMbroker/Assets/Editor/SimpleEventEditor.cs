using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SimpleEvent))]
public class SimpleEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (!EditorApplication.isPlaying) return;

        SimpleEvent simpleEvent = (SimpleEvent) target;
        if (GUILayout.Button("Fire!"))
        {
            simpleEvent.Fire();
            Debug.LogWarning("Simple Event!");
        }
    }
}