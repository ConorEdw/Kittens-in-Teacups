using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTracker : MonoBehaviour
{
    //Attach this script to the player character

    //Declaration of variable for tracking the player's travelled "distance"
    public int playerDistance = 0;


    // Update is called once per frame
    void Update()
    {
        //Constantly increases the player's tracked "distance" by 1
        playerDistance = playerDistance + 1;
    }
}
