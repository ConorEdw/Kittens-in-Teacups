using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMP : MonoBehaviour
{
    public float playerSpeed;
    private Vector2 inputDirection = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = inputDirection;
        moveDirection.y = 0; //We don't want to move up and down
        transform.position += (Vector3)moveDirection * playerSpeed * Time.deltaTime; // Time.deltaTime makes our movement consistent regardless of framerate
    }

    public void HandleDirectionalInput(Vector2 direction)
    {
        //Save the direciton to use later
        inputDirection = direction;
    }
    
    //public void HandleButtonInput(int buttonID)
    //{
      //  if (buttonID == 0)
        //{
            // Cannonball cannon = GetCannon();
            //if (cannon != null)
            //{
              //  cannon.Fire(transform.position);
            //}
        //}
    //}
}
