using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public struct DangerZoneInfo
{
    public DangerZone zone;
    public float distance;

    public DangerZoneInfo(DangerZone zone, float distance)
    {
        this.zone = zone;
        this.distance = distance;
    }
}


public class GasAnalyzer : MonoBehaviour
{
    private DangerZonesManager _dangerZonesManager;
    [SerializeField] private GasAnalyzerState _state;
    [SerializeField] private GasAnalyzerDisplay _display;
    [SerializeField] private Transform _zondEnd;


    void Start()
    {
        _dangerZonesManager = DangerZonesManager.Instance;
    }

    public void FixedUpdate()
    {
        DangerZoneInfo closestZoneInfo = GetClosestZone();
        if (_state.IsEnabled)
        {
            _display.UpdateCounterText(closestZoneInfo.distance);
        }
    }

    private DangerZoneInfo GetClosestZone()
    {
        DangerZone closestZone = null;
        foreach (DangerZone zone in _dangerZonesManager.DangerZones)
        {
            if (closestZone == null ||
                Vector3.Distance(_zondEnd.position, zone.transform.position) < Vector3.Distance(_zondEnd.position, closestZone.transform.position))
            {
                closestZone = zone;
            }
        }
        return new DangerZoneInfo(closestZone, Vector3.Distance(_zondEnd.position, closestZone.transform.position));
    }
}
