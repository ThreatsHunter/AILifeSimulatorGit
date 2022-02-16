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
        GameObject _ai = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        if (!_ai) return;
        _ai.name = "AI";
        _ai.AddComponent<ALS_AI>();
        _ai.AddComponent<NavMeshAgent>();
    }
}