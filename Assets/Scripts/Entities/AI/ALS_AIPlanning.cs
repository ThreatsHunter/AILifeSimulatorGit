using UnityEngine;

[System.Serializable]
public class ALS_AIPlanning
{
    [SerializeField] ALS_PlanningDay[] services = new ALS_PlanningDay[7];

    public ALS_Service this[int _day, int _hour]
    {
        get => services[_day][_hour];
        set => services[_day][_hour] = value;
    }
}