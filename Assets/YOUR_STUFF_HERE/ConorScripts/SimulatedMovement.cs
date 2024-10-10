using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedMovement : MonoBehaviour
{
    //Attach this script to the game environment game object(s)

    //Attach a parent game object that contains both the background and obstacles as children into this variable
    public GameObject gameEnvironment;

    //Amount that the game environment moves, serving as the movement speed (Y-Axis)
    public float gEnvMovementAmount = 0.01f;

    //Declaration of variable for storing game envrionment's current position
    private Vector2 currentPosition;


    // Update is called once per frame
    void Update()
    {
        //Constantly keeps track of the game environment's current position in the currentPosition variable
        currentPosition = gameEnvironment.transform.position;

        //Constantly alters the game environment's position along the Y-Axis
        gameEnvironment.transform.position = new Vector2(currentPosition.x, currentPosition.y - gEnvMovementAmount);
    }
}
