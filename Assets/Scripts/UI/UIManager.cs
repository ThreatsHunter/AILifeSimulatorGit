using UnityEngine;

public class UIManager : SingletonTemplate<UIManager>
{
    #region f/p
    [SerializeField] UIWorld uiWorld = null;

    public bool IsValid => uiWorld;
    public UIWorld UIWorld => uiWorld;
    #endregion

    #region methods
    private void Start()
    {
        if (IsValid)
            return;

        uiWorld = GetComponent<UIWorld>();
    }
    #endregion
}
