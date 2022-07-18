using System;
using UnityEngine;

class PlayerController
{
    private const float DEAD_TIME = 1f;
    private PlayerInput _playerInput;
    private PlayerTank _playerTank;
    private PlayerMono _playerInstance;
    private float _currentDeadTime = 0f;
    private bool _isAlive;
    private Vector3 _startSpawnPosition = new Vector3(-6.5f, 0f, -6.5f);
    private GameObject _bulletPrototype;
    private Vector3 _lastDirection;

    public PlayerController(ref Action OnUpdate, ref Action OnFixedUpdate, ref Action OnLateUpdate, ref PlayerMono playerMonoPrototype, GameObject bulletPrototype)
    {
        _bulletPrototype = bulletPrototype;
        _playerInstance = InstanceManager.Instantiate(playerMonoPrototype);
        _playerInstance.OnDeath += this.OnDeath;
        _playerInput = new PlayerInput(ref OnUpdate);
        _playerInput.OnShoot += Shoot;
        _playerTank = new PlayerTank(ref _playerInstance.rigidbody, ref OnUpdate);
        OnFixedUpdate += this.OnFixedUpdate;
        OnUpdate += this.OnUpdate;
        Spawn();
    }

    private void OnUpdate()
    {
        if (!_isAlive)
        {
            _currentDeadTime += Time.deltaTime;
            if (_currentDeadTime >= DEAD_TIME)
            {
                Spawn();
            }
        }

        if (_playerInput.Direction != Vector3.zero)
        {
            _lastDirection = _playerInput.Direction;
        }
    }

    private void OnFixedUpdate()
    {
        _playerTank.Move(_playerInput.Direction);
    }

    private void OnDeath()
    {
        _isAlive = false;
        _playerInstance.gameObject.SetActive(false);
    }

    private void Shoot()
    {
        Debug.Log(_lastDirection);
        GameObject bullet = InstanceManager.Instantiate(_bulletPrototype);
        bullet.transform.position = _playerInstance.transform.position + _lastDirection;
        bullet.GetComponent<Rigidbody>().velocity = _lastDirection * 15f;
    }

    private void Spawn()
    {
        _isAlive = true;
        _playerInstance.transform.position = _startSpawnPosition;
        _playerInstance.gameObject.SetActive(true);
    }
}
