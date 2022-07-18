using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMono : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 7)
        {
            Destroy(this.gameObject);
        }
    }
}
