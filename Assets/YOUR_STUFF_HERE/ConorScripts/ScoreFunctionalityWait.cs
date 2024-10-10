using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFunctionalityWait : MonoBehaviour
{
    //Attach this script to the player character

    //Declaration of variables that will be used to store their respective scripts
    private ScoreFunctionality scoreFunctionality;
    private DistanceTracker distanceTracker;

    //Declaration of variable for storing the tutorial game object
    public GameObject Tutorial;

    //Declaration of variable for determining if the tutorial has started
    private bool tutorialHasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        //Stores the scripts in these variables
        scoreFunctionality = GetComponent<ScoreFunctionality>();
        distanceTracker = GetComponent<DistanceTracker>();

        //Sets these scripts to automatically be disabled upon project start
        scoreFunctionality.enabled = false;
        distanceTracker.enabled = false;
    }

    //Determines when the score is allowed to start accumulating
    private IEnumerator WaitForTutorial()
    {
        //Checks if the tutorial is active, then sets the tutorialHasStarted boolean to true
        if (Tutorial.activeInHierarchy == true)
        {
            tutorialHasStarted = true;

            yield return null;
        }

        //Enables the scoreFunctionality and distanceTracker if the tutorialHasStarted variable is set to true
        if (tutorialHasStarted == true)
        {
            scoreFunctionality.enabled = true;
            distanceTracker.enabled = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitForTutorial());
    }
}
