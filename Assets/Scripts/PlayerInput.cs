using System;
using UnityEngine;

public sealed class PlayerInput
{
    private Vector3 _direction;
    public event Action OnShoot;
    public PlayerInput(ref Action OnUpdate)
    {
        OnUpdate += this.Update;
    }

    private void Update()
    {
        _direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _direction = new Vector3(_direction.x, _direction.y, 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction = new Vector3(_direction.x, _direction.y, -1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction = new Vector3(-1f, _direction.y, _direction.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction = new Vector3(1f, _direction.y, _direction.z);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnShoot?.Invoke();
        }
    }

    public Vector3 Direction => _direction;
}
