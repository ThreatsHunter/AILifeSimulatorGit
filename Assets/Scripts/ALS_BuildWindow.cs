using System;
using UnityEditor;
using UnityEngine;

public class ALS_BuildWindow : EditorWindow
{
    event Action OnGUIUpdated = null;

    const string SKIN_ASSET = "PlanningSkin";

    GameObject buildObject = null;
    Color buildColor = Color.white;
    string buildName = string.Empty;
    bool[ , ] buildPlanning = new bool[7, 24];
    bool isHouse = false;
    Vector2 scrollPosition = Vector2.zero;
    GUISkin skin = null;
    //planning

    public bool IsValid => buildObject;

    private void OnEnable()
    {
        skin = Resources.Load<GUISkin>(SKIN_ASSET);

        OnGUIUpdated += () =>
        {
            Display();
        };
    }
    private void OnGUI() => OnGUIUpdated?.Invoke();
    private void OnDisable()
    {
        OnGUIUpdated = null;
    }

    void Display()
    {
        // Build datas
        EditorGUILayout.LabelField("Set build data");
        buildObject = EditorGUILayout.ObjectField("Set build", buildObject, typeof(UnityEngine.Object), true) as GameObject;
        buildColor = EditorGUILayout.ColorField("Set build color", buildColor);
        isHouse = EditorGUILayout.Toggle("Is a house ?", isHouse);

        if (!isHouse)
        {
            // name
            buildName = EditorGUILayout.TextField("Set build name", buildName);
            EditorGUILayout.Space(20.0f);

            // Planning
            EditorGUILayout.LabelField("Set build planning");
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            EditorGUILayout.BeginHorizontal();
            for (int _day = -1; _day < 7; _day++)
            {
                EditorGUILayout.BeginVertical();
                EditorGUILayout.LabelField(GetDay(_day));

                for (int _hour = 0; _hour < 24; _hour++)
                {
                    if (_day == -1)
                    {
                        EditorGUILayout.LabelField($"{_hour} :");
                        EditorGUILayout.Space(11.0f);
                        continue;
                    }

                    bool _task = buildPlanning[_day, _hour];

                    if (GUILayout.Button("", GetButtonStyle(0, Color.white, _task ? Color.green : Color.red, Color.gray)))
                    {
                        buildPlanning[_day, _hour] = !_task;
                    }

                    EditorGUILayout.Space(5.0f);
                }

                EditorGUILayout.EndVertical();
                EditorGUILayout.Space(3.0f);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndScrollView();
        }

        // Create build
        if (GUILayout.Button("Create", GetButtonStyle(22, Color.white, Color.green, Color.gray)))
        {
            if (!IsValid) return;
            if (isHouse)
                buildObject.AddComponent<ALS_Home>();
            else
                buildObject.AddComponent<ALS_Service>();

            ALS_Build _build = buildObject.GetComponent<ALS_Build>();
            if (!_build) return;
            _build.BuildColor = buildColor;

            if (!isHouse)
            {
                ALS_Service _service = _build.GetComponent<ALS_Service>();
                if (!_service) return;
                _service.ServiceName = buildName;
                _service.BuildPlanning = new ALS_BuildPlanning(buildPlanning);
            }

            Selection.activeGameObject = buildObject;
            Close();
        }
    }

    GUIStyle GetButtonStyle(int _fontSize, Color _textColor, Color _normalColor, Color _hoverColor)
    {
        GUIStyle _style = new GUIStyle(skin.button);
        _style.fontSize = _fontSize;
        _style.normal.textColor = _textColor;
        _style.hover.textColor = Color.green;
        _style.normal.background = GetTextureColor(_normalColor);
        _style.hover.background = GetTextureColor(_hoverColor);
        _style.fontStyle = FontStyle.Bold;
        return _style;
    }
    GUIStyle GetLabelStyle(int _size, Color _color)
    {
        GUIStyle _style = new GUIStyle(GUI.skin.label);
        _style.fontSize = _size;
        _style.hover.textColor = _color;
        _style.fontStyle = FontStyle.Italic;
        return _style;
    }
    Texture2D GetTextureColor(Color _color)
    {
        Texture2D _t2d = new Texture2D(1, 1);
        _t2d.SetPixel(1, 1, _color);
        _t2d.Apply();
        return _t2d;
    }
    string GetDay(int _dayIndex)
    {
        switch (_dayIndex)
        {
            case 0:
                return "Lundi :";
            case 1:
                return "Mardi :";
            case 2:
                return "Mercredi :";
            case 3:
                return "Jeudi :";
            case 4:
                return "Vendredi :";
            case 5:
                return "Samedi :";
            case 6:
                return "Dimanche :";
            default:
                return "";
        }
    }
}