using UnityEngine;

public class ALS_AIPlanning
{
    [SerializeField] ALS_Service[ , ] services = new ALS_Service[7, 24];

    public ALS_Service this[int _day, int _hour] => services[_day, _hour];

    public void UpdatePlanning(int _day, int _hour, ALS_Service _service)
    {
        if (!_service) return;
        services[_day, _hour] = _service;
    }
}