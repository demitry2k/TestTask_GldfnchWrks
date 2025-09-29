using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RemoteButton : MonoBehaviour
{
    [SerializeField] private RemoteController _remoteController;
    [SerializeField] private Renderer _renderer;
    public UnityEvent OnPressStartEvent;
    public UnityEvent OnPressEndEvent;
    private bool _alreadyPressed = false;
    private void OnTriggerStay(Collider other)
    {
        ContactFinger contactFinger = null;
        if (other.tag == "ContactFinger" && other.TryGetComponent<ContactFinger>(out contactFinger))
        {
            if (contactFinger.IsPressed)
            {
                if (!_alreadyPressed && !_remoteController.ArePressesBlocked)
                {
                    _renderer.enabled = true;
                    OnPressStart();
                }
            }
            else
            {
                _renderer.enabled = false;
                OnPressEnd();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ContactFinger contactFinger = null;
        if (other.tag == "ContactFinger" && other.TryGetComponent<ContactFinger>(out contactFinger))
        {
            _renderer.enabled = false;
            OnPressEnd();
        }
    }
    private void OnPressStart()
    {
        Debug.Log("Pressed " + name);
        _alreadyPressed = true;
        _remoteController.ArePressesBlocked = true;
        OnPressStartEvent.Invoke();
    }
    private void OnPressEnd()
    {
        Debug.Log("Released " + name);
        _alreadyPressed = false;
        _remoteController.ArePressesBlocked = false;
        OnPressEndEvent.Invoke();
    }
}
