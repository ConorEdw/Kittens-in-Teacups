using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCannonBall : MonoBehaviour
{
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        // If cannonball collides with another cannonball, they destroy each other
        //if (collision.gameObject.tag == "CannonBall" || collision.gameObject.tag == "Fish")
        //{
            // Spawn on hit VFX

            // Destroy functionality
            //Destroy(gameObject);
        //}
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "CannonBall":
                Destroy(gameObject);
                break;
            case "Fish":
                Destroy(gameObject);
                break;
        }
    }
}
