using UnityEngine;

public abstract class ALS_Build : MonoBehaviour
{
    [SerializeField] int amount = 0, capacity = 50;

    public Color BuildColor { get; set; } = Color.white;

    private void OnTriggerEnter(Collider other)
    {
        ALS_AI _ia = other.gameObject.GetComponent<ALS_AI>();
        if (!_ia || !CanEnter()) return;
        _ia.SetActive(false);
        amount++;
    }
    private void OnTriggerExit(Collider other)
    {
        ALS_AI _ia = other.gameObject.GetComponent<ALS_AI>();
        if (!_ia) return;
        _ia.SetActive(true);
        amount--;
    }

    protected virtual bool CanEnter() => amount <= capacity;
}