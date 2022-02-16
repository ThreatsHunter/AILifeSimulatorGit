using UnityEngine;

public class ALS_Service : ALS_Build
{
    [SerializeField] ALS_BuildPlanning buildPlanning = new ALS_BuildPlanning();

    public bool IsOpen => buildPlanning[World.Instance.Day, World.Instance.Hour];
    public string ServiceName { get; set; } = string.Empty;
    public ALS_BuildPlanning Planning => buildPlanning;

    /*public override bool CanEnter()
    {
        return base.CanEnter() && IsOpen;
    }*/
}