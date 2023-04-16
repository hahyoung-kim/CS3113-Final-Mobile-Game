using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnList;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float ogTBS;
    private float ogMinX;
    private float ogMaxX;
    private float spawnTime;
    public GameObject player;
    private float startTime;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        ogTBS = timeBetweenSpawn;
        ogMinX = minX;
        ogMaxX = maxX;
        startTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.time - startTime;
        if (elapsedTime >= 1) {
            timeBetweenSpawn = ogTBS - (float)(Math.Log(elapsedTime) * 0.6);
            print("tbs " + timeBetweenSpawn);
            minX = ogMinX - (float)(Math.Log(elapsedTime)*2);
            maxX = ogMaxX - (float)(Math.Log(elapsedTime)*2);
        }
        
        if (minX < 10) {
            minX = 10;
        }
        if (maxX < 10) {
            maxX = 10;
        }
        if (timeBetweenSpawn < 1.5f) {
            timeBetweenSpawn = 1.5f;
        }
        if (elapsedTime > spawnTime) {
            int spawnType = UnityEngine.Random.Range(0, 2);
            GameObject toSpawn;
            if (spawnType == 0) {
                toSpawn = spawnList[UnityEngine.Random.Range(0, 2)];
            } else {
                toSpawn = spawnList[UnityEngine.Random.Range(2, spawnList.Length)]; 
            }
            SpawnObj(toSpawn);
            spawnTime = elapsedTime + timeBetweenSpawn;
        }
        
    }

    void SpawnObj(GameObject toSpawn) {
        float randomX = UnityEngine.Random.Range(minX, maxX);
        float randomY = UnityEngine.Random.Range(minY, maxY);

        Instantiate(toSpawn, new Vector3(randomX + player.transform.position.x, randomY, 0), transform.rotation);
    }
}
