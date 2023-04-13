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
    private GameObject toSpawn;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime) {
            toSpawn = spawnList[Random.Range(0, spawnList.Length)];
            SpawnObj();
            spawnTime = Time.time + timeBetweenSpawn;
        }
        
    }

    void SpawnObj() {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(toSpawn, transform.position + new Vector3(randomX + player.transform.position.x, randomY, 0), transform.rotation);
    }
}
