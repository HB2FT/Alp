using TMPro;
using Unity.VisualScripting;
using UnityEditor;  
using UnityEngine;

[CustomEditor(typeof(Button))]
public class Button_Editor : Editor
{
    Button _target;

    TextMeshPro text;
    ButtonOverlay overlay;

    private void OnEnable()
    {
        _target = (Button)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Sa"))
        {
            Debug.Log("Pressed");
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(_target);
        }
    }
}
