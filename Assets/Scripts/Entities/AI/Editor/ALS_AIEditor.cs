using System;
using UnityEditor;
using UnityEngine;
using CustomLibraryEditor.TemplateEditor;

[CustomEditor(typeof(ALS_AI))]
public class ALS_AIEditor : CustomTemplateEditor<ALS_AI>
{
    event Action OnInspectorOverride = null;

	const string SKIN_ASSET = "PlanningSkin";

	GUISkin skin = null;

	protected override void OnEnable()
	{
        base.OnEnable();
		skin = Resources.Load<GUISkin>(SKIN_ASSET);

		OnInspectorOverride += () =>
		{
			GUI.skin = skin;
			GUILayout.FlexibleSpace();
			DisplayAIPlanning();
			GUILayout.FlexibleSpace();
			serializedObject.ApplyModifiedProperties();
			SceneView.RepaintAll();
		};
	}
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		OnInspectorOverride?.Invoke();
	}

	void DisplayAIPlanning()
    {
		if (GUILayout.Button("Edit AI planning", ALS_WindowStyle.GetButtonStyle(skin.button, 22, Color.white, Color.green)))
        {
			ALS_AIWindow _aiWindow = EditorWindow.GetWindow<ALS_AIWindow>(true, "Edit AI planning", true);
			if (!_aiWindow) return;
			_aiWindow.SetTarget(eTarget);
		}
	}
}