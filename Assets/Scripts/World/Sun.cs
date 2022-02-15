using UnityEngine;
using System;

[Serializable]
public class Sun
{
    #region f/p
    [SerializeField] Light directionalLight = null;
    [SerializeField] Gradient directionalColor = null;

    public bool IsValid => directionalLight;
    #endregion

    #region methods
    public void ChangeSun(float _percent)
    {
        if (!IsValid)
            return;

        directionalLight.color = directionalColor.Evaluate(_percent);
        directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((_percent * 360f) - 90f, 180f, 0f));
    }
    #endregion
}
