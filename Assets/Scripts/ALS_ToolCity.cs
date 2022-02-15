using UnityEditor;

public class ALS_ToolCity
{
    [MenuItem("Tool / Build")]
    public static void InitBuild()
    {
        EditorWindow.GetWindow<ALS_BuildWindow>(true, "Init Build");
    }
    
    [MenuItem("Tool / AI")]
    public static void InitAI()
    {
        EditorWindow.GetWindow<ALS_AIWindow>(true, "Init AI");
    }
}