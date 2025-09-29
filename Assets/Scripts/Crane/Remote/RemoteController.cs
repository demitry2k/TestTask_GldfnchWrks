using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RemoteController : MonoBehaviour
{
    [SerializeField] private RemoteButton upButton;
    [SerializeField] private RemoteButton downButton;
    [SerializeField] private RemoteButton eastButton;
    [SerializeField] private RemoteButton westButton;
    [SerializeField] private RemoteButton northButton;
    [SerializeField] private RemoteButton southButton;

    public UnityEvent upPressStartEvent;
    public UnityEvent upPressEndEvent;
    public UnityEvent downPressStartEvent;
    public UnityEvent downPressEndEvent;
    public UnityEvent eastPressStartEvent;
    public UnityEvent eastPressEndEvent;
    public UnityEvent westPressStartEvent;
    public UnityEvent westPressEndEvent;
    public UnityEvent northPressStartEvent;
    public UnityEvent northPressEndEvent;
    public UnityEvent southPressStartEvent;
    public UnityEvent southPressEndEvent;

    private bool _arePressesBlocked;

    public bool ArePressesBlocked { get => _arePressesBlocked; set => _arePressesBlocked = value; }

    private void Start()
    {
        upButton.OnPressStartEvent.AddListener(upPressStartEvent.Invoke);
        upButton.OnPressEndEvent.AddListener(upPressEndEvent.Invoke);
        downButton.OnPressStartEvent.AddListener(downPressStartEvent.Invoke);
        downButton.OnPressEndEvent.AddListener(downPressEndEvent.Invoke);
        eastButton.OnPressStartEvent.AddListener(eastPressStartEvent.Invoke);
        eastButton.OnPressEndEvent.AddListener(eastPressEndEvent.Invoke);
        westButton.OnPressStartEvent.AddListener(westPressStartEvent.Invoke);
        westButton.OnPressEndEvent.AddListener(westPressEndEvent.Invoke);
        northButton.OnPressStartEvent.AddListener(northPressStartEvent.Invoke);
        northButton.OnPressEndEvent.AddListener(northPressEndEvent.Invoke);
        southButton.OnPressStartEvent.AddListener(southPressStartEvent.Invoke);
        southButton.OnPressEndEvent.AddListener(southPressEndEvent.Invoke);
    }
}
