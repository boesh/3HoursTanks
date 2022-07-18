using System;
using UnityEngine;

public class PlayerMono : MonoBehaviour
{
    public Rigidbody rigidbody;
    public event Action OnDeath;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            OnDeath.Invoke();
        }
    }
}
