using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NotificationDataEvent))]
public class NotificationDataEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (!EditorApplication.isPlaying) return;

        NotificationDataEvent notificationDataEvent = (NotificationDataEvent) target;
        if (GUILayout.Button("Fire default"))
        {
            notificationDataEvent.Fire(new NotificationData("Something important happened!", 2f, 1f, 0.2f));
        }
    }
}