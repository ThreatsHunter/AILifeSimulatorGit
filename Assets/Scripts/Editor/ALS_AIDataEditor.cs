//using System;
//using UnityEditor;
//using UnityEngine;
//using CustomLibraryEditor.TemplateEditor;
//using CustomLibraryEditor.GUIEditor;

//[CustomEditor(typeof(ALS_AIData))]
//public class ALS_AIDataEditor : CustomTemplateEditor<ALS_AIData>
//{
//    event Action OnInspectorOverrided = null; 

//    protected override void OnEnable()
//    {
//        base.OnEnable();

//        OnInspectorOverrided += () =>
//        {
//			GUILayout.FlexibleSpace();
//            DrawPlanningGUI();
//			GUILayout.FlexibleSpace();
//            //serializedObject.ApplyModifiedProperties();
//        };
//    }
//    //public override void OnInspectorGUI() => OnInspectorOverrided?.Invoke();

//    void DrawPlanningGUI()
//    {
//        //CustomGUIEditor.CreateButton(new Rect(0, 0, 200, 200), "Planning", Color.green, eTarget.SetPlanning);
//    }
//}