using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZonesManager : MonoBehaviour
{
    private static DangerZonesManager instance;
    [SerializeField] private List<DangerZone> dangerZones;

    public static DangerZonesManager Instance { get => instance; }
    public List<DangerZone> DangerZones { get => dangerZones; set => dangerZones = value; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddZone(DangerZone zone)
    {
        if (!dangerZones.Contains(zone))
        {
            dangerZones.Add(zone);
        }
    }

    public void SetRenderersVisibility(bool value)
    {
        foreach (DangerZone zone in dangerZones)
        {
            zone.SetRendererVisibility(value);
        }
    }
}
