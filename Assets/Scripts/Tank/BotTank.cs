using System;
using UnityEngine;

public class BotTank : BaseTank
{
    private event Action<Vector3> _onChangeDirection;
    private event Action _onDeath;

    public BotTank(ref Rigidbody rigidbody, ref Action<Collision> OnCollistionEnter, ref Action<Vector3> OnChangeDirection, ref Action OnDeath) : base(ref rigidbody)
    {
        OnCollistionEnter += this.OnCollisionEnter;
        _onChangeDirection = OnChangeDirection;
        _onDeath = OnDeath;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3 || collision.gameObject.layer == 6)
        {
            _onChangeDirection?.Invoke(collision.contacts[0].normal);
        }

        if (collision.gameObject.layer == 8)
        {
            _onDeath?.Invoke();
        }
    }
}

