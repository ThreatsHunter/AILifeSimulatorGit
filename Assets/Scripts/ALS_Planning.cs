using UnityEditor;
using UnityEngine;

public class ALS_BuildPlanning
{
    [SerializeField] bool[ , ] isOpen = null;

    public ALS_BuildPlanning(bool[ , ] _tasks)
    {
        isOpen = _tasks;
    }
}

public class ALS_AIPlanning : MonoBehaviour
{
    [SerializeField] ALS_Build[ , ] targets = null;

    public ALS_Build this[int _day, int _hour] => targets[_day, _hour];

    public ALS_AIPlanning(Service[][] _services)
    {
             
    }

    public void EditPlanning()
    {
        // ouvre le planning deja set et save
        EditorWindow.GetWindow<ALS_AIWindow>(true, "Edit AI");
    }
}