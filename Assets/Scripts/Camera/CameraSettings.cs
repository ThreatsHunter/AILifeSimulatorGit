using UnityEngine;
using System;

[Serializable]
public struct LookOffset
{
    [SerializeField, Range(-50, 50)] float xOffset, yOffset, zOffset;
    public Vector3 GetRawOffset => new Vector3(xOffset, yOffset, zOffset);
    public float X => xOffset;
    public float Y => yOffset;
    public float Z => zOffset;

    public LookOffset(float _xOffset = 0, float _yOffset = 0, float _zOffset = 0)
    {
        xOffset = _xOffset;
        yOffset = _yOffset;
        zOffset = _zOffset;
    }
}

[Serializable]
public struct OffsetCamera
{
    [SerializeField, Range(-50, 50)] float xOffset, yOffset, zOffset;
    [SerializeField] bool isLocalOffset;

    public bool IsLocalOffset => isLocalOffset;
    public Vector3 GetRawOffset => new Vector3(xOffset, yOffset, zOffset);
    public float X => xOffset;
    public float Y => yOffset;
    public float Z => zOffset;

    public OffsetCamera(float _xOffset = 0, float _yOffset = 0, float _zOffset = 0, bool _isLocalOffset = true)
    {
        xOffset = _xOffset;
        yOffset = _yOffset;
        zOffset = _zOffset;
        isLocalOffset = _isLocalOffset;
    }

    public void SetY(float _y) => yOffset = _y;

    public float GetDistance() => Mathf.Sqrt(Mathf.Pow(GetDistanceWithoutHeight(), 2) + Mathf.Pow(yOffset, 2));

    public float GetDistanceWithoutHeight() => Mathf.Sqrt(Mathf.Pow(xOffset, 2) + Mathf.Pow(zOffset, 2));

    public Vector3 GetLocalOffset(Transform _transform)
    {
        if (_transform == null)
            return Vector3.zero;

        Vector3 _x = _transform.right * xOffset;
        Vector3 _y = _transform.up * yOffset;
        Vector3 _z = _transform.forward * zOffset;
        return _transform.position + _x + _y + _z;
    }

    public Vector3 GetWorldOffset(Transform _transform) => _transform ? _transform.position + new Vector3(xOffset, yOffset, zOffset) : Vector3.zero;
};

[Serializable]
public class CameraSettings
{
    #region f/p
    #region fields
    [SerializeField] Transform target = null;
    [SerializeField] Camera cameraRender = null;
    [SerializeField] OffsetCamera offset = new OffsetCamera();
    [SerializeField] LookOffset lookOffset = new LookOffset();
    [SerializeField] bool cameraCanMove = true, cameraCanRotate = true;
    [SerializeField] float cameraMoveSpeed = 2, cameraRotateSpeed = 10;
    #endregion

    #region properties
    public bool IsValidCamera => target && cameraRender;
    public Vector3 CurrentPosition => cameraRender ? cameraRender.transform.position : Vector3.zero;
    public Vector3 TargetPosition => target ? target.position + target.TransformVector(lookOffset.GetRawOffset) : CurrentPosition;
    public Transform Target => target;
    public OffsetCamera Offset => offset;
    public Quaternion CurrentRotation => IsValidCamera ? cameraRender.transform.rotation : Quaternion.identity;
    public bool CameraCanMove => cameraCanMove;
    public bool CameraCanRotate => cameraCanRotate;
    public float CameraMoveSpeed => cameraMoveSpeed;
    public float CameraRotateSpeed => cameraRotateSpeed;
    #endregion
    #endregion

    #region methods
    public CameraSettings(Transform _target = null) => target = _target;

    public void Init(Transform _origin)
    {
        if (!_origin)
            return;
        cameraRender = _origin.GetComponent<Camera>();
    }

    public void SetCameraCanMove(bool _cameraCanMove) => cameraCanMove = _cameraCanMove;

    public void SetCameraCanRotate(bool _cameraCanRotate) => cameraCanRotate = _cameraCanRotate;

    public void SetCameraRender(bool _cameraRender) => cameraRender.enabled = _cameraRender;

    public void SetYOffset(float _y) => offset.SetY(_y);

    public void SetTarget(Transform _transform) => target = _transform;
    #endregion
}
