using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLogicMP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall" || collision.tag == "Fish")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Fish")
        {
            Destroy(gameObject);
        }
    }
}
