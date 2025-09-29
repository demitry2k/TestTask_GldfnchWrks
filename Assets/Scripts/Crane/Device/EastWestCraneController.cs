using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EastWestCraneController : CraneControllerBase
{
    [Space]
    [Header("Настройки направлений движения:")]
    [SerializeField] private DirectionParameters _east;
    [SerializeField] private DirectionParameters _west;

    private void Start()
    {
        _startPosition = _movableObject.position;
        _remoteController.eastPressStartEvent.AddListener(MoveEast);
        _remoteController.eastPressEndEvent.AddListener(StopMoving);
        _remoteController.westPressStartEvent.AddListener(MoveWest);
        _remoteController.westPressEndEvent.AddListener(StopMoving);
    }

    public void MoveEast()
    {
        _CurrentDirection = _east;
    }

    public void MoveWest()
    {
        _CurrentDirection = _west;
    }

    public void StopMoving()
    {
        StopSound(_CurrentDirection);
        _CurrentDirection = null;
    }
}
