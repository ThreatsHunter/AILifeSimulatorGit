using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ALS_AIWindow : EditorWindow
{
    event Action OnGUIUpdated = null;

    const string SKIN_ASSET = "PlanningSkin";
    GUISkin skin = null;
    ALS_Build[ , ] allBuilds = new ALS_Build[7, 24];
    ALS_Build[] builds = null;
    int index = 0;
    string[] buildsName = null;
    Vector2 scrollPosition = Vector2.zero;

    private void OnEnable()
    {
        skin = Resources.Load<GUISkin>(SKIN_ASSET);
        builds = FindObjectsOfType<ALS_Build>();
        SetBuildName();
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
        EditorGUILayout.LabelField("Set AI planning");
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

                index = EditorGUILayout.Popup(index, buildsName);

                EditorGUILayout.Space(5.0f);
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(3.0f);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();

        // Create ai
        if (GUILayout.Button("Create", GetButtonStyle(22, Color.white, Color.green, Color.gray)))
        {
            GameObject _ai = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            _ai.AddComponent<ALS_AI>();
            _ai.AddComponent<NavMeshAgent>();
            Close();
        }
    }

    void SetBuildName()
    {
        buildsName = new string[builds.Length];
        for (int i = 0; i < builds.Length; i++)
        {
            buildsName[i] = builds[i].name;
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