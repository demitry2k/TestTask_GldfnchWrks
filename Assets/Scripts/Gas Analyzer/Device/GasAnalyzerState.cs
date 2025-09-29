using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GasAnalyzerState : MonoBehaviour
{ 
    private bool _isEnabled = false;
    [SerializeField] private AudioSource _audioSource;
    public UnityEvent OnStateEnableEvent;
    public UnityEvent OnStateDisableEvent;

    public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }

    private void Start()
    {
        if (_isEnabled)
        {
            OnStateEnableEvent.Invoke();
        }
        else
        {
            OnStateDisableEvent.Invoke();
        }
        DangerZonesManager.Instance.SetRenderersVisibility(_isEnabled);
    }

    public void SwitchState()
    {
        SetState(!_isEnabled);
    }

    public void SetState(bool state)
    {
        _isEnabled = state;
        if (state)
        {
            OnStateEnableEvent.Invoke();
        }
        else
        {
            OnStateDisableEvent.Invoke();
        }
        _audioSource.Play();
        DangerZonesManager.Instance.SetRenderersVisibility(state);
    }
}
