using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCannonBall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If cannonball collides with another cannonball, they destroy each other
        if (collision.gameObject.tag == "CannonBall")
        {
            // Spawn on hit VFX

            // Destroy functionality
            Destroy(gameObject);
        }
    }
}
