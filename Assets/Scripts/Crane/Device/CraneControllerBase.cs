using HTC.UnityPlugin.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DirectionParameters
{
    public Bool3 direction;
    public bool invert;
    public float speed = 1;
    public float moveLimit = 4;
    public AudioSource sound;
}
public class CraneControllerBase : MonoBehaviour
{
    [SerializeField] protected RemoteController _remoteController;
    [SerializeField] protected Transform _movableObject;
    protected DirectionParameters _CurrentDirection;
    protected Vector3 _startPosition;


    void Update()
    {
        if (_CurrentDirection != null)
        {
            MoveCrane(_CurrentDirection);
        }
    }

    public virtual void MoveCrane(DirectionParameters directionParameters)
    {
        Vector3 newPosition = Vector3.MoveTowards(_movableObject.position, _movableObject.position + ConvertBool3ToVector3(directionParameters.direction, directionParameters.invert) * _CurrentDirection.speed * Time.deltaTime, 0.2f);
        if ((directionParameters.direction.x && MathF.Abs((newPosition - _startPosition).x) < _CurrentDirection.moveLimit)
            || (directionParameters.direction.y && MathF.Abs((newPosition - _startPosition).y) < _CurrentDirection.moveLimit)
            || (directionParameters.direction.z && MathF.Abs((newPosition - _startPosition).z) < _CurrentDirection.moveLimit))
        {
            _movableObject.position = newPosition;
            PlaySound(directionParameters);
        }
        else
        {
            StopSound(directionParameters);
        }
    }

    private void PlaySound(DirectionParameters directionParameters)
    {
        if (directionParameters.sound != null && !directionParameters.sound.isPlaying)
        {
            directionParameters.sound.Play();
        }
    }
    protected void StopSound(DirectionParameters directionParameters)
    {
        if (directionParameters?.sound != null)
        {
            directionParameters.sound.Stop();
        }
    }

    public Vector3 ConvertBool3ToVector3(Bool3 direction, bool invert)
    {
        Vector3 point = new Vector3(direction.x ? 1 : 0, direction.y ? 1 : 0, direction.z ? 1 : 0) * (invert ? -1 : 1);
        return point;
    }
}
