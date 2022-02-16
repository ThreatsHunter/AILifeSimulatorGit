using UnityEngine;

public abstract class ALS_Build : MonoBehaviour
{
    [SerializeField] int amount = 0, capacity = 50;
    [SerializeField] Color buildColor = Color.white;

    public Color BuildColor { get => buildColor; set => buildColor = value; }

    public virtual bool CanEnter() => amount <= capacity;
}