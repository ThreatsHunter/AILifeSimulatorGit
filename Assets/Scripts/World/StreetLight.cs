using UnityEngine;

public class StreetLight : MonoBehaviour
{
    #region f/p
    [SerializeField] Light[] streetLight = null;
    [SerializeField, Range(0, 23)] int iLightUp = 18, iLightDown = 6; 

    public bool IsValid => streetLight.Length > 0;
    #endregion

    #region methods
    private void Start()
    {
        World.Instance.OnHourChanged += (day, hour) => ChangeLight(hour);
        ChangeLight(World.Instance.Hour);
    }

    void ChangeLight(int _hour)
    {
        if (!IsValid)
            return;

        bool _enable = _hour < iLightUp && _hour > iLightDown;

        for (int i = 0; i < streetLight.Length; i++)
            streetLight[i].gameObject.SetActive(!_enable);
    }
    #endregion
}
