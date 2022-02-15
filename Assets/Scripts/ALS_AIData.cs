using UnityEditor;
using UnityEngine;

//[AddComponentMenu("Planning")]
public class ALS_AIData : MonoBehaviour
{
    public void SetPlanning() => EditorWindow.GetWindow<ALS_Planning>(true, "Define planning");
}