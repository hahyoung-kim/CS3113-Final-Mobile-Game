using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnList;
    public string[] spawnYBounds;
    //GameManager _gameManager;

    public float maxX;
    public float minX;
    public float timeBetweenSpawn;
    private float ogTBS;
    private float ogMinX;
    private float ogMaxX;
    private float spawnTime;
    public GameObject player;
    private float startTime;
    private float elapsedTime;
    private int spawnInd;

    // Start is called before the first frame update
    void Start()
    {
        ogTBS = timeBetweenSpawn;
        ogMinX = minX;
        ogMaxX = maxX;
        startTime = Time.time;
        //_gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        //if (_gameManager.GetLives() > 0) {
            elapsedTime = Time.time - startTime;
            if (elapsedTime >= 1) {
                timeBetweenSpawn = ogTBS - (float)(Math.Log(elapsedTime) * 0.6);
                minX = ogMinX - (float)(Math.Log(elapsedTime));
                maxX = ogMaxX - (float)(Math.Log(elapsedTime));
            }
            
            if (minX < 10) {
                minX = 10;
            }
            if (maxX < 10) {
                maxX = 10;
            }
            if (timeBetweenSpawn < 0.5f) {
                timeBetweenSpawn = 0.5f;
            } 
            if (elapsedTime > spawnTime) {
                SpawnObj();
                spawnTime = elapsedTime + timeBetweenSpawn;
            }
        //}
    }

    void SpawnObj() {
        int spawnType = UnityEngine.Random.Range(0, 2);

        if (spawnType == 0) {
            spawnInd = UnityEngine.Random.Range(0, 2);
        } else {
            spawnInd = UnityEngine.Random.Range(2, spawnList.Length);
        }

        float randomX = UnityEngine.Random.Range(minX, maxX);
        string[] ys = spawnYBounds[spawnInd].Split(",");
        float minY = float.Parse(ys[0]);
        float maxY = float.Parse(ys[1]);
        float randomY = UnityEngine.Random.Range(minY, maxY);

        Instantiate(spawnList[spawnInd], new Vector3(randomX + player.transform.position.x, randomY, 0), transform.rotation);
    }
}
