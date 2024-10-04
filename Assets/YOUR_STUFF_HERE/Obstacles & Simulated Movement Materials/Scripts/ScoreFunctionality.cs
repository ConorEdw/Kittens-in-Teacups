using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UI;

public class ScoreFunctionality : MonoBehaviour
{
    //Attach this script to the player character

    //Declaration of variables for the player's score
    private int startingPlayerScore = 0;
    private int currentPlayerScore;
    private int finalPlayerScore;

    //Declaration of variable needed for determining whether or not the player's score accumulates
    private bool cannotAccumulate = false;

    //Declaration of variable needed for storing the distanceTracker script
    private DistanceTracker distanceTracker;

    //Declaration of variables needed for displaying the score, distance and final score on-screen
    public Text scoreNumber;
    public Text distanceNumber;
    public Text finalScoreNumber;


    void Start()
    {
        //Sets the player score at the start to be the starting score
        currentPlayerScore = startingPlayerScore;

        //Stores the DistanceTracker script in a variable
        distanceTracker = GetComponent<DistanceTracker>();
    }

    //Raises the player's score every second
    private IEnumerator RaiseScoreEverySecond()
    {
        //Raises the player's score by 10
        currentPlayerScore = currentPlayerScore + 10;

        //Serves as a one second wait timer
        yield return new WaitForSeconds(1f);
    }


    //If the player collides with an obstacle, sets the cannotAccumulate variable to true
    //All obstacles MUST have the "Obstacle" tag
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            //Sets the cannotAccumulate variable to true
            cannotAccumulate = true;
        }
    }

    //Calls the wasHit function after 2 seconds
    private void OnTriggerExit2D(Collider2D other)
    {
        Invoke("wasHit", 2f);
    }

    //Sets the cannotAccumulate variable to false
    private void wasHit()
    {
        cannotAccumulate = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If the cannotAccumulate variable is false, the RaiseScoreEverySecond coroutine is called
        if (!cannotAccumulate)
        {
            //Calls RaiseScoreEverySecond coroutine
            StartCoroutine(RaiseScoreEverySecond());
        }

        //Prevents the player's score from going below zero
        if (currentPlayerScore < 0)
        {
            currentPlayerScore = 0;
        }

        //Stores the player's final score using the currentPlayerScore * playerDistance
        finalPlayerScore = currentPlayerScore * distanceTracker.playerDistance;

        //Displays the player's current score on screen
        scoreNumber.text = currentPlayerScore.ToString();

        //Displays the player's travelled "distance" on screen
        distanceNumber.text = distanceTracker.playerDistance.ToString();

        //Displays the player's final score on screen
        finalScoreNumber.text = finalPlayerScore.ToString();
    }
}
