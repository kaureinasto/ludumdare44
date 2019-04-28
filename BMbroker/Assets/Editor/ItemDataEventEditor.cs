using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemDataEvent))]
public class ItemDataEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        if (!EditorApplication.isPlaying) return;
        
        ItemDataEvent myScript = (ItemDataEvent) target;
        if (GUILayout.Button("Fire Event!"))
        {
            myScript.Fire(myScript.defaultItemData);
        }
    }
}