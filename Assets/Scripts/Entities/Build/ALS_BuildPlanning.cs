using UnityEngine;

public class ALS_BuildPlanning
{
    [SerializeField] bool[ , ] buildPlanning = null;

    public bool this[int _day, int _hour] => buildPlanning[_day, _hour];

    public void UpdatePlanning(int _day, int _hour, bool _status)
    {
        buildPlanning[_day, _hour] = _status;
    }
}