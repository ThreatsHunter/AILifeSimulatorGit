using UnityEngine;

public class CameraActor : MonoBehaviour
{
    #region f/p
    [SerializeField] TPSCamera tpsCamera = null;
    [SerializeField] float fMoveSpeed = 100;

    public bool IsValid => tpsCamera;
    #endregion

    #region methods
    private void Update()
    {
        if (!IsValid)
            return;

        Zoom(-Input.mouseScrollDelta.y);
        MoveForward(Input.GetAxis("Vertical"));
        MoveRight(Input.GetAxis("Horizontal"));
    }

    void MoveForward(float _axis)
    {
        transform.position += transform.forward * _axis * (fMoveSpeed * Time.deltaTime);
    }

    void MoveRight(float _axis)
    {
        transform.position += transform.right * _axis * (fMoveSpeed * Time.deltaTime);
    }

    void Zoom(float _axis)
    {
        if (_axis == 0)
            return;

        float _y = tpsCamera.Settings.Offset.Y;
        _y += _axis;
        _y = Mathf.Clamp(_y, 10, 100);
        tpsCamera.Settings.SetYOffset(_y);
    }
    #endregion
}
