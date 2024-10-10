using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LaneChange : MonoBehaviour
{
    //Declaration of rigidbody component
    private Rigidbody2D rb;


    //Distance between two lanes (X-axis)
    public float laneDistance = 6;


    //The left-most and right-most lanes positions (X-axis)
    private float leftmostLimit;
    private float rightmostLimit;


    //Variables for various states of position of this game object
    private Vector2 startingPosition;
    private float positionDifference;
    private Vector2 currentPosition;


    // Start is called before the first frame update
    void Start()
    {
        //Assignment of attached rigidbody component to variable
        rb = GetComponent<Rigidbody2D>();


        //Stores the starting position of this game object in a variable (Must be at position (0,0))
        startingPosition = this.gameObject.transform.position;


        //Must be set to the negative and positive of laneDistance respectively
        leftmostLimit = -laneDistance;
        rightmostLimit = laneDistance;

    }


    // Update is called once per frame
    void Update()
    {
        //Constantly keeps track of this game object's current position
        currentPosition = this.gameObject.transform.position;


        //Alters the position of this game object depending on what direction has been pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            positionDifference = startingPosition.x - laneDistance; //Stores the result of start position - lane distance

            this.gameObject.transform.position = new Vector2(currentPosition.x - -positionDifference, 0); //-positionDifference resolves issues with double negatives
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            positionDifference = startingPosition.x + laneDistance; //Stores the result of start position + lane distance

            this.gameObject.transform.position = new Vector2(currentPosition.x + positionDifference, 0);
        }


        //Prevents this game object from going beyond the furthest lanes on each side by resetting its position back to its current
        if (currentPosition.x == leftmostLimit)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.gameObject.transform.position = new Vector2(currentPosition.x, 0);
            }
        }

        if (currentPosition.x == rightmostLimit)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.gameObject.transform.position = new Vector2(currentPosition.x, 0);
            }
        }
    }
}
