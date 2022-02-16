using UnityEngine;

public abstract class ALS_Build : MonoBehaviour
{
    [SerializeField] int amount = 0, capacity = 50;

    public Color BuildColor { get; set; } = Color.white;

    public virtual bool CanEnter()
    {
        bool _enter = amount <= capacity;

        if (_enter)
            amount++;

        return _enter;
    }
}