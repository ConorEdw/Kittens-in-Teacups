using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFunctionality : MonoBehaviour
{
    //Attach this script to the obstacles


    //Stops the player when they collide with this obstacle
    //All players MUST have the "Player" tag
    //Obstacle colliders MUST be marked as triggers
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Disables the player's SimulatedMovement script, preventing the game environment from moving
            other.GetComponent<SimulatedMovement>().enabled = false;
        }
    }


    //Starts the player again when they move out of the way of this obstacle
    private void OnTriggerExit2D(Collider2D other)
    {
        //Re-enables the player's SimulatedMovement script, making the game environment move again
        other.GetComponent<SimulatedMovement>().enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
