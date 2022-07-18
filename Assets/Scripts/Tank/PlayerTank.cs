using System;
using UnityEngine;

class PlayerTank : BaseTank, IShootable    
{
    public PlayerTank(ref Rigidbody rigidbody, ref Action OnUpdate) : base(ref rigidbody)
    {
        
    }

    public void Shoot()
    {

    }
}

