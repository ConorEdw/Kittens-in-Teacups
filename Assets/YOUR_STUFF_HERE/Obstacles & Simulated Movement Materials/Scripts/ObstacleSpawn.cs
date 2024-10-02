using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    //Attach this script on an empty "obstacle spawner" game object

    //Declared variable for the obstacles
    public GameObject obstaclePrefab;

    //Declared variable to serve as the means to have a parent object for the spawned obstacles
    //This MUST be correctly assigned with the "Game Environment" game object or else spawned obstacles will not move toward player
    public GameObject gameEnvironmentParent;

    //Declared variables to determine when an obstacle will be spawned
    public float timeLimitForSpawn = 2f;
    private float spawnTimer;


    //Starts a timer as to when an obstacle will be spawned when triggered
    private void SpawnCycle()
    {
        //Starts the spawn timer relative to real-time
        spawnTimer += Time.deltaTime;

        //Once the spawnTimer reaches or exceeds the time limit, the function for spawning an obstacle is triggered
        if(spawnTimer >= timeLimitForSpawn)
        {
            //Triggers the SpawnObstacle function
            SpawnObstacle();

            //Resets the spawnTimer back to zero
            spawnTimer = 0;
        }
    }


    //Spawns an obstacle when triggered
    private void SpawnObstacle()
    {
        //The spawn location will be a random location on the X-axis between -6 and 6 (7 is an exclusive value and wont appear)
        //The spawn location will also be at 6 on the Y-axis
        Vector2 spawnLocation = new Vector2(Random.Range(-6, 7), 6);

        //Spawns the obstacle at the location
        //Quaternion.identity prevents rotation
        //gameEnvironmentParent.transform makes the obstacles spawn as children of the game environment, meaning they move with it
        Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity, gameEnvironmentParent.transform);

    }


    // Update is called once per frame
    void Update()
    {
        //Triggers the SpawnCycle function
        SpawnCycle();
    }
}
