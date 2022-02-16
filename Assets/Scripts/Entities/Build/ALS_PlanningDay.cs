using UnityEngine;

[System.Serializable]
public class ALS_PlanningDay
{
    [SerializeField] ALS_Service[] services = new ALS_Service[24];
    
    public ALS_Service this[int _hour]
    {
        get => services[_hour];
        set => services[_hour] = value;
    }
}