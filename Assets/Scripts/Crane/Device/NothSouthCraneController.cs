using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothSouthCraneController : CraneControllerBase
{
    [Space]
    [Header("Настройки направлений движения:")]
    [SerializeField] private DirectionParameters _north;
    [SerializeField] private DirectionParameters _south;

    private void Start()
    {
        _startPosition = _movableObject.position;
        _remoteController.northPressStartEvent.AddListener(MoveNorth);
        _remoteController.northPressEndEvent.AddListener(StopMoving);
        _remoteController.southPressStartEvent.AddListener(MoveSouth);
        _remoteController.southPressEndEvent.AddListener(StopMoving);
    }

    public void MoveNorth()
    {
        _CurrentDirection = _north;
    }

    public void MoveSouth()
    {
        _CurrentDirection = _south;
    }

    public void StopMoving()
    {
        StopSound(_CurrentDirection);
        _CurrentDirection = null;
    }
}
