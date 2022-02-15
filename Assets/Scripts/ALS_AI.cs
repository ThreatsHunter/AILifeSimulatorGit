using UnityEngine;
using UnityEngine.AI;

public class ALS_AI : MonoBehaviour
{
    [SerializeField] Transform currentTarget = null;

    public bool IsValid => currentTarget;

    public void SetActive(bool _status)
    {
        GetComponent<Renderer>().enabled = _status;
        GetComponent<NavMeshAgent>().enabled = _status;
    }
}