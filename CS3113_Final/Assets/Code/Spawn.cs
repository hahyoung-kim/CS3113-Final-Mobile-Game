using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnList;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime) {
            int spawnType = Random.Range(0, 2);
            GameObject toSpawn;
            if (spawnType == 0) {
                toSpawn = spawnList[Random.Range(0, 2)];
            } else {
                toSpawn = spawnList[Random.Range(2, spawnList.Length)]; 
            }
            SpawnObj(toSpawn);
            spawnTime = Time.time + timeBetweenSpawn;
        }
        
    }

    void SpawnObj(GameObject toSpawn) {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(toSpawn, transform.position + new Vector3(randomX + player.transform.position.x, randomY, 0), transform.rotation);
    }
}
