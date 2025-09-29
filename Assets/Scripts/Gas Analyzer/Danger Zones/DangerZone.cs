using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DangerZone : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Renderer _renderer;
    void Start()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
        DangerZonesManager.Instance.AddZone(this);
    }

    public void SetRendererVisibility(bool value)
    {
        _renderer.enabled = value;
    }
}
