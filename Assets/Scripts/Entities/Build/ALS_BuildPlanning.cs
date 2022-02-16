using System;
using UnityEngine;

[Serializable]
public class ALS_BuildPlanning
{
    [SerializeField] ALS_BuildDay[] buildPlanning = new ALS_BuildDay[7];

    public bool this[int _day, int _hour] => buildPlanning[_day][_hour];

    public void UpdatePlanning(int _day, int _hour, bool _status)
    {
        buildPlanning[_day][_hour] = _status;
    }
}

[Serializable]
public class ALS_BuildDay
{
    [SerializeField] bool[] buildDay = new bool[24];

    public bool this[int _hour]
    {
        get => buildDay [_hour];
        set => buildDay [_hour] = value;
    }
}