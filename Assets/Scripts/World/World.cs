using UnityEngine;
using TMPro;

public class World : MonoBehaviour
{
    #region f/p
    [SerializeField] Sun sun = new Sun();
    [SerializeField, Range(0, 10)] float fWorldAcceleration = 1;
    [SerializeField] float fHourLength = 1;
    [SerializeField, Range(0, 1440)] float fTime = 0;
    [SerializeField] TMP_Text timeText = null;
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
        fTime = Mathf.Clamp(fTime, 0f, 24f * 60f);

        if(timeText)
            timeText.text = $"{((int)(fTime / 60f)).ToString("00")}:{(fTime % 60).ToString("00")}";
    }
        
    void ChangeSun()
    {
        float _timePercent = fTime / (24f * 60f);
        RenderSettings.ambientLight = sun.AmbientColor.Evaluate(_timePercent);
        RenderSettings.fogDensity = _timePercent <= .5f ? Mathf.Lerp(sun.FogDensityMax, sun.FogDensityMin, _timePercent * 2)
                                                        : Mathf.Lerp(sun.FogDensityMin, sun.FogDensityMax, (_timePercent - .5f) * 2);

        if (!sun.IsValid)
            return;

        sun.DirectionalLight.color = sun.DirectionalColor.Evaluate(_timePercent);
        sun.DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((_timePercent * 360f) - 90f, 180f, 0f));
    }

    public void SetWorldAcceleration(float _acceleration) => fWorldAcceleration = _acceleration;
    #endregion
}
