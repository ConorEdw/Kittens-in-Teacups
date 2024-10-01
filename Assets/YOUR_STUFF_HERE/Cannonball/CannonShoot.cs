using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    // Getting positions A = left | B = right of ship
    public Transform pointA;
    public Transform pointB;

    // Getting prefab of cannonball gameobject to spawn at either point
    public GameObject cannonBall;

    // Speed of cannonball shot
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Shooting cannonball left if left button pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Spawning cannonball under cannon variable at either left or right position
            var cannon = (GameObject)Instantiate(cannonBall, pointA.position, pointA.rotation);

            // using cannon variable to use the cannon's rigidbody physics to shoot it left or right
            cannon.GetComponent<Rigidbody2D>().velocity = cannon.transform.right * -speed;
        }

        // Shooting cannonball left if left button pressed
        if (Input.GetMouseButtonDown(1))
        {
            var cannon = (GameObject)Instantiate(cannonBall, pointB.position, pointB.rotation);

            cannon.GetComponent<Rigidbody2D>().velocity = cannon.transform.right * speed;
        }
    }
}
