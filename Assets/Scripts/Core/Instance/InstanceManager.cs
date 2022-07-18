using System;
using UnityEngine;

public class InstanceManager: MonoBehaviour
{
    public event Action OnUpdate;
    public event Action OnFixedUpdate;
    public event Action OnLateUpdate;

    private PlayerController _playerController;
    private BotsManager _botsManager;


    [SerializeField]
    private PlayerMono _playerPrototype;

    [SerializeField]
    private BotMono _botPrototype;

    [SerializeField]
    private GameObject _bulletPrototype;

    private void Awake()
    {
        _playerController = new PlayerController(ref OnUpdate, ref OnFixedUpdate, ref OnLateUpdate, ref _playerPrototype, _bulletPrototype);
        _botsManager = new BotsManager(ref OnUpdate, ref OnFixedUpdate, ref OnLateUpdate, ref _botPrototype);
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }

    private void LateUpdate()
    {
        OnLateUpdate?.Invoke();
    }
}