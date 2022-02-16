using System;
using UnityEditor;
using UnityEngine;

public class ALS_BuildWindow : EditorWindow
{
    event Action OnGUIUpdated = null;

    const string SKIN_ASSET = "PlanningSkin";

    GUISkin skin = null;
    Vector2 scrollPosition = Vector2.zero;
    ALS_Service service = null;

    private void OnEnable()
    {
        skin = Resources.Load<GUISkin>(SKIN_ASSET);
        OnGUIUpdated += () =>
        {
            DisplayPlanning();
        };
    }
    private void OnGUI() => OnGUIUpdated?.Invoke();
    private void OnDisable()
    {
        OnGUIUpdated = null;
    }

    void DisplayPlanning()
    {
        if (!service) return;

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

                bool _task = service.IsOpen;

                if (GUILayout.Button("", ALS_WindowStyle.GetButtonStyle(skin.button, 0, Color.white, _task ? Color.green : Color.red)))
                {
                    service.Planning.UpdatePlanning(_day, _hour, !_task);
                }

                EditorGUILayout.Space(5.0f);
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(3.0f);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
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