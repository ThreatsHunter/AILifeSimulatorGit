using UnityEngine;

public class ALS_AI : MonoBehaviour
{
    [SerializeField] Transform currentTarget = null;

    public bool IsValid => currentTarget;
}