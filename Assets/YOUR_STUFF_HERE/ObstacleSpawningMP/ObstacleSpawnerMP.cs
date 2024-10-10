using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerMP : MonoBehaviour
{
    // public Transform[] spawners;

    Transform randomSpawner;

    public Transform spawnerL;
    public Transform spawnerR;

    public GameObject obstacle;

    public float speed;
    public float cooldown;
    bool hasCalled = false;

    private void Start()
    {
        if (!hasCalled)
        {
            StartCoroutine(spawnObstacle());
        }
    }

    IEnumerator spawnObstacle()
    {
        while (!hasCalled)
        {
            // randomSpawner = spawners[Random.Range(0, spawners.Length)];
            float leftX = spawnerL.position.x;
            float rightX = spawnerR.position.x;
            float y = spawnerL.position.y;

            Vector2 randomSpawn = new Vector2(Random.Range(leftX, rightX), y);
            GameObject newOB = Instantiate(obstacle, randomSpawn, Quaternion.identity);
            //GameObject newOB = Instantiate(obstacle, randomSpawner.transform.position, Quaternion.identity);
            newOB.transform.Translate(Vector3.down * speed * Time.deltaTime);

            yield return new WaitForSeconds(cooldown);
        }
    }
}
