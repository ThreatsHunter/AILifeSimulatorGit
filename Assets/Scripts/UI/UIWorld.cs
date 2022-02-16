using UnityEngine;
using TMPro;

public class UIWorld : MonoBehaviour
{
    #region f/p
    [SerializeField] TMP_Text timeText = null, accelerationText = null;

    public bool IsValid => timeText && accelerationText;
    #endregion

    #region methods
    public void SetAcceleration(float _acceleration)
    {
        if (!IsValid)
            return;

        accelerationText.text = $"x{_acceleration.ToString("0")}";
    }

    public void SetTime(float _time, int _day)
    {
        if (!IsValid)
            return;

        timeText.text = $"<b>{GetDay(_day)}</b>{((int)(_time / 60f)).ToString("00")}:{(_time % 60).ToString("00")}";
    }

    string GetDay(int _dayIndex)
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
                return "Unknown :";
        }
    }
    #endregion
}
