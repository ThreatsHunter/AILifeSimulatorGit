using UnityEngine;
using System;

[Serializable]
public class Sun
{
    #region f/p
    [SerializeField] Light directionalLight = null;
    [SerializeField] Gradient ambientColor = null, directionalColor = null;
    [SerializeField, Range(0, 1)] float fogDensityMax = .2f, fogDensityMin = 0;

    public bool IsValid => directionalLight;
    public Light DirectionalLight { get => directionalLight; set => directionalLight = value; }
    public Gradient AmbientColor => ambientColor;
    public Gradient DirectionalColor => directionalColor;
    public float FogDensityMax { get => fogDensityMax; set => fogDensityMax = value; }
    public float FogDensityMin => fogDensityMin;
    #endregion
}
