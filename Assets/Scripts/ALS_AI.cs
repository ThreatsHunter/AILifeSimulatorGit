using UnityEngine;
using UnityEngine.AI;

public class ALS_AI : MonoBehaviour
{
    [SerializeField] ALS_AIPlanning planning = null;
    [SerializeField] NavMeshAgent navigation = null;
    [SerializeField] Transform currentTarget = null;

    public bool IsValid => planning && navigation;

    private void Start()
    {
        navigation = GetComponent<NavMeshAgent>();
        World.Instance.OnHourChanged += SetCurrentTarget;
    }
    private void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (!IsValid) return;
        navigation.speed = World.Instance.WorldAcceleration * 3.5f;
        navigation.angularSpeed = World.Instance.WorldAcceleration * 120.0f;
        navigation.acceleration = World.Instance.WorldAcceleration * 8.0f;
        navigation.SetDestination(currentTarget.position);
    }
    void SetCurrentTarget(int _day, int _hour)
    {
        if (!IsValid) return;
        currentTarget = planning[_day, _hour].transform;
    }

    public void SetActive(bool _status)
    {
        GetComponent<Renderer>().enabled = _status;
        GetComponent<NavMeshAgent>().enabled = _status;
    }
}