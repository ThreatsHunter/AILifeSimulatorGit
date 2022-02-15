using UnityEngine;

public class ALS_Service : ALS_Build
{
    [SerializeField] string serviceName = string.Empty;
    [SerializeField] Service[][] services;
    [SerializeField] ALS_BuildPlanning buildPlanning = null;

    public string ServiceName { get => serviceName; set => serviceName = value; }
    public ALS_BuildPlanning BuildPlanning { get => buildPlanning; set => buildPlanning = value; }
}