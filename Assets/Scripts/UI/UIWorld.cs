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

        string _dayText = "";

        switch (_day)
        {
            case 0: _dayText = "Lundi : ";
                break;
            case 1: _dayText = "Mardi : ";
                break;
            case 2: _dayText = "Mercredi : ";
                break;
            case 3: _dayText = "Jeudi : ";
                break;
            case 4: _dayText = "Vendredi : ";
                break;
            case 5: _dayText = "Samedi : ";
                break;
            case 6: _dayText = "Dimanche : ";
                break;
            default: _dayText = "Unknown : ";
                break;
        }

        timeText.text = $"<b>{_dayText}</b>{((int)(_time / 60f)).ToString("00")}:{(_time % 60).ToString("00")}";
    }
    #endregion
}
