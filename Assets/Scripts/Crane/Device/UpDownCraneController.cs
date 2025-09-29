using Obi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Внимание! Имеет базовый класс
public class UpDownCraneController : CraneControllerBase
{
    [Space]
    [Header("Настройки направлений движения:")]
    [SerializeField] private DirectionParameters _up;
    [SerializeField] private DirectionParameters _down;
    [SerializeField] private Transform _bobine;
    [SerializeField] private Transform _cable;

    private void Start()
    {
        _startPosition = _movableObject.position;
        _remoteController.upPressStartEvent.AddListener(MoveUp);
        _remoteController.upPressEndEvent.AddListener(StopMoving);
        _remoteController.downPressStartEvent.AddListener(MoveDown);
        _remoteController.downPressEndEvent.AddListener(StopMoving);
    }

    public override void MoveCrane(DirectionParameters directionParameters)
    {
        Vector3 newPosition = Vector3.MoveTowards(_movableObject.position, _movableObject.position + ConvertBool3ToVector3(directionParameters.direction, directionParameters.invert) * _CurrentDirection.speed * Time.deltaTime, 0.2f);
        if ((directionParameters.direction.x && MathF.Abs((newPosition - _startPosition).x) < _CurrentDirection.moveLimit)
            || (directionParameters.direction.y && MathF.Abs((newPosition - _startPosition).y) < _CurrentDirection.moveLimit)
            || (directionParameters.direction.z && MathF.Abs((newPosition - _startPosition).z) < _CurrentDirection.moveLimit))
        {
            _movableObject.position = newPosition;
            _cable.localScale = new Vector3(_cable.localScale.x, _cable.localScale.y + (_CurrentDirection.invert ? 1 : -1) * _CurrentDirection.speed * Time.deltaTime, _cable.localScale.z);
            _bobine.localEulerAngles = new Vector3(_bobine.localEulerAngles.x + 40 * (_CurrentDirection.invert ? 1 : -1) * _CurrentDirection.speed * Time.deltaTime, _bobine.localEulerAngles.y, _bobine.localEulerAngles.z);
        }
        if (directionParameters.sound != null && !directionParameters.sound.isPlaying)
        {
            directionParameters.sound.Play();
        }
    }
    public void MoveUp()
    {
        _CurrentDirection = _up;
    }

    public void MoveDown()
    {
        _CurrentDirection = _down;
    }

    public void StopMoving()
    {
        StopSound(_CurrentDirection);
        _CurrentDirection = null;
    }
}
