using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    #region f/p
    [SerializeField] CameraSettings settings = new CameraSettings();

    public CameraSettings Settings => settings;
    #endregion

    #region methods
    public void Update()
    {
        MoveTo();
        RotateTo();
    }

    public void MoveTo()
    {
        if (settings.IsValidCamera && settings.CameraCanMove)
            transform.position = GetPosition();
    }

    public void RotateTo()
    {
        if (settings.IsValidCamera && settings.CameraCanRotate)
        {
            Quaternion _rotation = GetRotation();
            Vector3 _euler = transform.eulerAngles;
            _euler.x = _rotation.eulerAngles.x;
            transform.eulerAngles = _euler;
        }
    }

    public Vector3 GetPosition()
    {
        Vector3 _offset = settings.Offset.IsLocalOffset ? settings.Offset.GetLocalOffset(settings.Target) : settings.Offset.GetWorldOffset(settings.Target);
        return Vector3.Lerp(settings.CurrentPosition, _offset, Time.deltaTime * settings.CameraMoveSpeed);
    }

    public Quaternion GetRotation()
    {
        Vector3 _lookAtDirection = settings.TargetPosition - settings.CurrentPosition;
        if (_lookAtDirection == Vector3.zero)
            return Quaternion.identity;

        Quaternion _lookAt = Quaternion.LookRotation(_lookAtDirection);
        return Quaternion.RotateTowards(settings.CurrentRotation, _lookAt, Time.deltaTime * settings.CameraRotateSpeed);
    }
    #endregion
}
