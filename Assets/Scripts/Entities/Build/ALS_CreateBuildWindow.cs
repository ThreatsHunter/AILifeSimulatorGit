using System;
using UnityEditor;
using UnityEngine;

public class ALS_CreateBuildWindow : EditorWindow
{
    event Action OnGUIUpdated = null;

    const string SKIN_ASSET = "PlanningSkin";

    bool isHouse = false;
    string buildName = string.Empty;
    Color buildColor = Color.white;
    GUISkin skin = null;
    GameObject buildObject = null;

    public bool IsValid => buildObject;

    private void OnEnable()
    {
        skin = Resources.Load<GUISkin>(SKIN_ASSET);
        OnGUIUpdated += () =>
        {
            CreateBuild();
        };
    }
    private void OnGUI() => OnGUIUpdated?.Invoke();
    private void OnDisable()
    {
        OnGUIUpdated = null;
    }

    void CreateBuild()
    {
        // Build datas
        EditorGUILayout.LabelField("Set build data");
        buildObject = (GameObject)EditorGUILayout.ObjectField("Set build", buildObject, typeof(GameObject), true);
        buildColor = EditorGUILayout.ColorField("Set build color", buildColor);
        isHouse = EditorGUILayout.Toggle("Is a house ?", isHouse);
        buildName = !isHouse ? EditorGUILayout.TextField("Set build name", buildName) : "House";
        EditorGUILayout.Space(20.0f);

        // Create build
        if (GUILayout.Button("Create", ALS_WindowStyle.GetButtonStyle(skin.button, 22, Color.white, Color.green)))
        {
            if (!IsValid) return;
            if (isHouse)
                buildObject.AddComponent<ALS_Home>();
            else
                buildObject.AddComponent<ALS_Service>();

            ALS_Build _build = buildObject.GetComponent<ALS_Build>();
            if (!_build) return;
            _build.name = buildName;
            _build.BuildColor = buildColor;

            if (!isHouse)
            {
                ALS_Service _service = _build.GetComponent<ALS_Service>();
                if (!_service) return;
                _service.ServiceName = buildName;
            }

            Selection.activeGameObject = buildObject;
            Close();
        }
    }
}