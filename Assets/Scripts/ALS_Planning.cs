using UnityEngine;

public class ALS_BuildPlanning
{
    [SerializeField] bool[ , ] isOpen = null;

    public ALS_BuildPlanning(bool[ , ] _tasks)
    {
        isOpen = _tasks;
    }
}

public class ALS_AIPlanning
{
    [SerializeField] ALS_Build[][] targets = null;

    public ALS_AIPlanning()
    {
        
    }
}