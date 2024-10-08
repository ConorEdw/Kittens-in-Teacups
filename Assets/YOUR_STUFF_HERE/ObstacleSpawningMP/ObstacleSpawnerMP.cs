using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerMP : MonoBehaviour
{
    public GameObject[] spawners;

    GameObject randomSpawner;
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
            randomSpawner = spawners[Random.Range(0, spawners.Length)];
            GameObject newOB = Instantiate(obstacle, randomSpawner.transform.position, Quaternion.identity);
            newOB.transform.Translate(Vector3.down * speed * Time.deltaTime);

            yield return new WaitForSeconds(cooldown);
        }
    }
}
