using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMechanic : MonoBehaviour
{
    // Referencing each wall for later
    GameObject rightWall;
    GameObject leftWall;

    // To prevent object from looping again instantly after already teleporting
    bool _looped = false;

    // To keep count of each loop to then destroy object after 2nd loop
    int _loopCount = 0;

    private void Start()
    {
        // Referencing the walls..
        rightWall = GameObject.Find("WallR");
        leftWall = GameObject.Find("WallL");
    }

    void Update()
    {
        // Constantly checking whether the cannonball has looped twice, if so then destroys it
        if (_loopCount >= 2)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.name)
        {
            // If cannonball collides with gameobject called WallL (left wall), and the cannonball has not looped, then it will
            // allow it to loop by setting its new transform position to the other wall's position. Afterwards, it sets looped bool
            // to true ensuring it won't instantly teleport again, and then increases the loop counter by 1. It then invokes the ResetLoop
            // function very quickly afterwards to set looped back to false so that the functionality will continue.
            case "WallL":
                if (!_looped)
                {
                    gameObject.transform.position = rightWall.transform.position;
                    _looped = true;
                    _loopCount++;
                    Invoke("ResetLoop", .1f);
                }
                break;

            case "WallR":
                if (!_looped)
                {
                    gameObject.transform.position = leftWall.transform.position;
                    _looped = true;
                    _loopCount++;
                    Invoke("ResetLoop", .1f);
                }
                break;
        }
    }
    void ResetLoop()
    {
        _looped = false;
    }
}
