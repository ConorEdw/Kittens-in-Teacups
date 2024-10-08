using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class ScoreFunctionality : MonoBehaviour
{
    //Attach this script to the player character

    //Declaration of variables for the player's score
    public int maximumPlayerScore = 100;
    private int currentPlayerScore;
    private int finalPlayerScore;


    //Declaration of variable for a score penalty
    public int scorePenalty = 5;

    void Start()
    {
        //Sets the player score at the start to be equal to the maximum
        currentPlayerScore = maximumPlayerScore;
    }

    //If the player collides with an obstacle, they incur a slight penalty to their score
    //All obstacles MUST have the "Obstacle" tag
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            currentPlayerScore = currentPlayerScore - scorePenalty;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Prevents the player's score from going below zero
        if (currentPlayerScore <= 0)
        {
            currentPlayerScore = 0;
        }

        //Registers the player's final score
        finalPlayerScore = currentPlayerScore;
    }
}
