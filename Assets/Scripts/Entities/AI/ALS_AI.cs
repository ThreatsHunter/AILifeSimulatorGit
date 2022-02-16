using UnityEngine;
using UnityEngine.AI;

public class ALS_AI : MonoBehaviour
{
    [SerializeField] ALS_Home home = null;
    [SerializeField] NavMeshAgent navigation = null;
    [SerializeField] ALS_Build currentTarget = null;
    [SerializeField] ALS_AIPlanning planning = new ALS_AIPlanning();

    public bool IsValid => home && navigation;
    public Vector3 TargetPosition => currentTarget ? currentTarget.transform.position : Vector3.zero;
    public ALS_AIPlanning Planning => planning;

    private void Start()
    {
        navigation = GetComponent<NavMeshAgent>();
        World.Instance.OnHourChanged += SetCurrentTarget;
    }
    private void Update() => MoveToTarget();
    private void OnDrawGizmosSelected()
    {
        if (!currentTarget) return;
        Gizmos.color = currentTarget.BuildColor;
        Gizmos.DrawWireSphere(transform.position, 10.0f);
        Gizmos.DrawWireSphere(TargetPosition, 10.0f);
    }

    void MoveToTarget()
    {
        if (!IsValid) return;
        navigation.speed = World.Instance.WorldAcceleration * 3.5f;
        navigation.angularSpeed = World.Instance.WorldAcceleration * 120.0f;
        navigation.acceleration = World.Instance.WorldAcceleration * 8.0f;
        navigation.SetDestination(TargetPosition);
    }
    void SetCurrentTarget(int _day, int _hour)
    {
        if (!IsValid) return;
        currentTarget = Planning[_day, _hour] ? Planning[_day, _hour] : (ALS_Build)home;
    }

    public void SetActive(bool _status)
    {
        GetComponent<Renderer>().enabled = _status;
        GetComponent<NavMeshAgent>().enabled = _status;
    }
}