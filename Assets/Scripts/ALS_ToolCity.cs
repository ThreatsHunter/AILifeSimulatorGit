using UnityEditor;
using UnityEngine;

public class ALS_ToolCity
{
    [MenuItem("Tool / Build")]
    public static void InitBuild()
    {
        GameObject _object = new GameObject("Build", typeof(ALS_BuildData));
        if (!_object) return;
        Selection.activeGameObject = _object;
    }
    
    [MenuItem("Tool / AI")]
    public static void InitAI()
    {
        GameObject _object = new GameObject("AI", typeof(ALS_AI), typeof(ALS_AIData));
        if (!_object) return;
        Selection.activeGameObject = _object;
    }
}