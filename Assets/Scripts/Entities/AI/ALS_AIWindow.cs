using System;
using UnityEditor;
using UnityEngine;

public class ALS_AIWindow : EditorWindow
{
    event Action OnGUIUpdated = null;

    const string SKIN_ASSET = "PlanningSkin";

    GUISkin skin = null;
    ALS_AI ai = null;
    Vector2 scrollPosition = Vector2.zero;

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
        if (!ai) return;
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
                    continue;
                }

                ALS_Service _service = (ALS_Service)EditorGUILayout.ObjectField(ai.Planning[_day, _hour], typeof(ALS_Service), true);
                if (!_service) continue;
                ai.Planning.UpdatePlanning(_day, _hour, _service);
                EditorGUILayout.Space(5.0f);
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(3.0f);
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();

        // Close the current window
        if (GUILayout.Button("Close", ALS_WindowStyle.GetButtonStyle(skin.button, 22, Color.white, Color.green)))
        {
            Close();
        }
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

    public void SetTarget(ALS_AI _target) => ai = _target;
}