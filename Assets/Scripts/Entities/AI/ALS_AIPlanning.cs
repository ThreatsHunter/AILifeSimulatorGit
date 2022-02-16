using UnityEngine;

[System.Serializable]
public class ALS_AIPlanning
{
    [SerializeField] ALS_PlanningDay[] services = new ALS_PlanningDay[7];

    public ALS_Service this[int _day, int _hour] => services[_day][_hour];

    public void UpdatePlanning(int _day, int _hour, ALS_Service _service)
    {
        if (!_service) return;
        services[_day][_hour] = _service;
    }
}