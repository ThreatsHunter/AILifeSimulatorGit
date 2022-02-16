using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ALS_ToolCity
{
    [MenuItem("Tool / Build")]
    public static void InitBuild()
    {
        EditorWindow.GetWindow<ALS_CreateBuildWindow>(true, "Create Build");
    }

    [MenuItem("Tool / AI")]
    public static void InitAI()
    {
        GameObject _object = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        if (!_object) return;
        _object.name = "AI";
        _object.transform.position = new Vector3(0.0f, 3.0f, -13.0f); 
        _object.AddComponent<ALS_AI>();
        _object.AddComponent<NavMeshAgent>();
    }
}