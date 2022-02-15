using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ALS_AIPlanning))]
public class ALS_AIPlanningEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        base.OnGUI(position, property, label);

        SerializedProperty _editButton = property.FindPropertyRelative("key");
        Rect _editButtonRect = new Rect(position.x, position.y, position.width / 2, position.height);

        if (EditorGUI.DropdownButton(_editButtonRect, GUIContent.none, FocusType.Keyboard))
            EditorWindow.GetWindow<ALS_AIWindow>(true, "Setup AI planning");
    }
}