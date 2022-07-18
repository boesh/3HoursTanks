using System;
using System.Collections.Generic;
using UnityEngine;

public class BotMono : MonoBehaviour
{
    public Rigidbody rigidbody;

    public Action<Collision> OnCollisionEnterEvent;

    private void OnCollisionEnter(Collision collision)
    {
        this.OnCollisionEnterEvent?.Invoke(collision);
    }
}
