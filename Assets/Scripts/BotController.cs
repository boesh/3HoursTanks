using System;
using UnityEngine;

public class BotController
{
    private BotBaseBehaviour _botBehaviour;
    private BotTank _botTank;
    private Action<Vector3> _OnChangeDirection;
    private BotMono _botMono;
    private Action _death;

    public BotController(ref Action OnUpdate, ref Action OnFixedUpdate, ref Action OnLateUpdate, ref BotMono botMonoPrototype, Vector3 startPosition)
    {
        _death += OnDeath;
        _botBehaviour = new BotBaseBehaviour(ref _OnChangeDirection, ref OnLateUpdate);
        _botMono = InstanceManager.Instantiate(botMonoPrototype);
        _botMono.transform.position = startPosition;
        _botTank = new BotTank(ref _botMono.rigidbody, ref _botMono.OnCollisionEnterEvent, ref _OnChangeDirection, ref _death);
        OnFixedUpdate += this.OnFixedUpdate;
    }

    private void OnDeath()
    {
        _botMono.gameObject.SetActive(false);
    }

    private void OnFixedUpdate()
    {
        _botTank.Move(_botBehaviour.Direction);
    }
}
