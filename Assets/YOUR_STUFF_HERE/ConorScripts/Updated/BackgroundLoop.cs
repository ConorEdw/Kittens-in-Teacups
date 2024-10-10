using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    //Attach this script to the game environment game object(s)
    
    //Declaration of variables for looping background
    //LoopTrigger game object MUST be a child of the game environment game object
    public GameObject LoopTrigger;
    public GameObject LoopTeleportLocation;

    //Declaration of variable for the location in which the loop trigger must be at before the background loops
    public float yAxisValue = -10f;

    // Update is called once per frame
    void Update()
    {
        //If the LoopTrigger object reaches the specified position (Y-Axis), moves the game environment game object (...)
        //(...) to the same position as the LoopTeleportLocation
        if (LoopTrigger.transform.position.y <= yAxisValue)
        {
            gameObject.transform.position = LoopTeleportLocation.transform.position;
        }
    }
}
