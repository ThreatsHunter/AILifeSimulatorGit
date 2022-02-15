using UnityEngine;
using System;

public class World : SingletonTemplate<World>
{
    #region f/p
    public event Action<int, int> OnHourChanged = null;

    [SerializeField] Sun sun = new Sun();
    [SerializeField, Range(0.0f, 10.0f)] float fWorldAcceleration = 1;
    [SerializeField] float fHourLength = 1;
    [SerializeField, Range(0, 6)] int iDay = 0;
    [SerializeField, Range(0, 23)] int iHour = 0;
    [SerializeField, Range(0, 1440)] float fTime = 0;

    public float WorldAcceleration => fWorldAcceleration;
    public int Day => iDay;
    public int Hour => iHour;
    #endregion

    #region methods
    private void Start()
    {
        InvokeRepeating(nameof(DoDayCycle), 0, 1);
    }

    void DoDayCycle()
    {
        ChangeSun();
        ChangeTime();
    }
    
    void ChangeTime()
    {
        fTime += (60f / (fHourLength * 60f)) * fWorldAcceleration;

        if (fTime >= 24f * 60f && fWorldAcceleration != 0)
        {
            iDay++;
            iDay %= 6;
        }

        if (fTime > iHour * 60f && fWorldAcceleration != 0)
        {
            iHour = Mathf.FloorToInt(fTime / 60f);
            iHour %= 24;
            OnHourChanged?.Invoke(iDay, iHour);
        }

        fTime %= 24f * 60f;
        UIManager.Instance.UIWorld.SetTime(fTime, iDay);
    }
        
    void ChangeSun()
    {
        float _timePercent = fTime / (24f * 60f);
        sun.ChangeSun(_timePercent);
    }

    public string GetDay(int _dayIndex)
    {
        switch (_dayIndex)
        {
            case 0:
                return "Lundi :";
            case 1:
                return "Mardi :";
            case 2:
                return "Mercredi :";
            case 3:
                return "Jeudi :";
            case 4:
                return "Vendredi :";
            case 5:
                return "Samedi :";
            case 6:
                return "Dimanche :";
            default:
                return "";
        }
    }
    public void SetWorldAcceleration(float _acceleration)
    {
        fWorldAcceleration = _acceleration;
        UIManager.Instance.UIWorld.SetAcceleration(_acceleration);
    }
    #endregion
}
