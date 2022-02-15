using UnityEngine;

public abstract class SingletonTemplate<T> : MonoBehaviour where T : MonoBehaviour
{
    #region f/p
    #region fields
    static T instance = default(T);
    #endregion

    #region properties
    public static T Instance => instance;
    #endregion
    #endregion

    #region methods
    protected virtual void Awake() => InitInstance();

    void InitInstance()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this as T;
        name += $" [{GetType().Name}]";
    }
    #endregion
}