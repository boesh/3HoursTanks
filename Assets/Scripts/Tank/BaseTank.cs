using UnityEngine;

public class BaseTank : IMovable
{
    protected Rigidbody _rigidbody;

    public BaseTank(ref Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction;
    }
}

