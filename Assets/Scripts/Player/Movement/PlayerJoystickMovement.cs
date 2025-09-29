using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;
    private bool _isGoingForward = false;
    private bool _isGoingBack = false;

    public bool IsGoingForward { get => _isGoingForward; set => _isGoingForward = value; }
    public bool IsGoingBack { get => _isGoingBack; set => _isGoingBack = value; }

    void FixedUpdate()
    {
        if (_isGoingForward)
        {
            GoForward();
        }
        if (_isGoingBack)
        {
            GoBack();
        }
    }

    public void GoForward()
    {
        Vector3 forward = new Vector3(_camera.forward.x, 0, _camera.forward.z);
        forward = forward.normalized;
        _player.position += forward * _speed * Time.deltaTime;
    }
    public void GoBack()
    {
        Vector3 forward = new Vector3(_camera.forward.x, 0, _camera.forward.z);
        forward = forward.normalized;
        _player.position += -forward * _speed * Time.deltaTime;
    }
}
