using System;
using UnityEditor;
using UnityEngine;
using CustomLibraryEditor.TemplateEditor;
using CustomLibraryEditor.GUIEditor;

[CustomEditor(typeof(ALS_AIPlanning))]
public class ALS_AIPlanningEditor : CustomTemplateEditor<ALS_AIPlanning>
{
    event Action OnInspectorOverrided = null;

    protected override void OnEnable()
    {
        base.OnEnable();

        OnInspectorOverrided += () =>
        {
            DrawInspectorGUI();
        };
    }
	public override void OnInspectorGUI() => OnInspectorOverrided?.Invoke();

    void DrawInspectorGUI()
    {
        CustomGUIEditor.CreateLayoutButton("Add new path", Color.green, eTarget.EditPlanning);
    }
}