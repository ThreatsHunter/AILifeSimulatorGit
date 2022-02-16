using System;
using UnityEditor;
using UnityEngine;
using CustomLibraryEditor.TemplateEditor;

[CustomEditor(typeof(ALS_Service))]
public class ALS_ServiceEditor : CustomTemplateEditor<ALS_Service>
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
			DisplayServicePlanning();
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

	void DisplayServicePlanning()
	{
		if (GUILayout.Button("Edit service planning", ALS_WindowStyle.GetButtonStyle(skin.button, 22, Color.white, Color.green)))
		{
			ALS_BuildWindow _window = EditorWindow.GetWindow<ALS_BuildWindow>(true, "Edit Service planning", true);
			if (!_window) return;
			_window.SetTarget(eTarget);
		}
	}
}
