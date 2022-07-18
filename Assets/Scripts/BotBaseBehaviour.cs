using System;
using UnityEngine;

public class BotBaseBehaviour
{
    private const float MAX_CHANGE_DIRECTION_TIME = 10f;
    private const float MIN_CHANGE_DIRECTION_TIME = 5f;
    private Vector3 _direction;
    private float _changeDirectionTime;

    public BotBaseBehaviour(ref Action<Vector3> OnChangeDirection, ref Action OnLateUpdate)
    {
        OnChangeDirection += this.OnChangeDirection;
        OnLateUpdate += this.OnLateUpdate;
        _changeDirectionTime = UnityEngine.Random.Range(MIN_CHANGE_DIRECTION_TIME, MAX_CHANGE_DIRECTION_TIME);
        SetRandomDirection();
    }

    private void OnLateUpdate()
    {
        _changeDirectionTime -= Time.deltaTime;
        if (_changeDirectionTime <= 0)
        {
            _changeDirectionTime = UnityEngine.Random.Range(MIN_CHANGE_DIRECTION_TIME, MAX_CHANGE_DIRECTION_TIME);
            SetRandomDirection();
        }
    }

    private void OnChangeDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void SetRandomDirection()
    {
        int s = UnityEngine.Random.Range(0, 4);
        if (s == 0)
        {
            _direction = Vector3.forward;
        }
        else if (s == 1)
        {
            _direction = -Vector3.forward;
        }
        else if (s == 2)
        {
            _direction = Vector3.left;
        }
        else if (s == 3)
        {
            _direction = Vector3.right;
        }
    }

    public Vector3 Direction => _direction;
}
