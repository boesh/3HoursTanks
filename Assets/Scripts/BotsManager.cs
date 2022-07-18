using System;
using System.Collections.Generic;
using UnityEngine;

class BotsManager
{
    private const int BOTS_COUNT = 5;

    private List<BotController> _bots;

    public BotsManager(ref Action OnUpdate, ref Action OnFixedUpdate, ref Action OnLateUpdate, ref BotMono botMonoPrototype)
    {
        _bots = new List<BotController>();
        for (int i = 0; i < BOTS_COUNT; i++)
        {
            _bots.Add(new BotController(ref OnUpdate, ref OnFixedUpdate, ref OnLateUpdate, ref botMonoPrototype, new Vector3(1.5f, 0f, 1.5f) * i));
        }
    }
}