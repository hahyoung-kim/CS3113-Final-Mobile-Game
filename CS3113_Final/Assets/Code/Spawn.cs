using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnList;
    public string[] spawnYBounds;
    GameManager _gameManager;
    public int thornsMinInd;
    public int thornsMaxInd;
    public int carrotsMinInd;
    public int carrotsMaxInd;
    public int powersMinInd;
    public int powersMaxInd;

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
    private bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        ogTBS = timeBetweenSpawn;
        ogMinX = minX;
        ogMaxX = maxX;
        startTime = Time.time;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine(WaitSpawn());
    }

    public IEnumerator WaitSpawn(){
        yield return new WaitForSeconds(3.5f);
        start = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (_gameManager.GetLives() > 0 && start) {
            elapsedTime = Time.time - startTime;
            if (elapsedTime >= 1) {
                timeBetweenSpawn = ogTBS - (float)(Math.Log(elapsedTime) * 0.6);
                minX = ogMinX - (float)(Math.Log(elapsedTime));
                maxX = ogMaxX - (float)(Math.Log(elapsedTime));
            }
            
            if (minX < 12) {
                minX = 12;
            }
            if (maxX < 15) {
                maxX = 15;
            }
            if (timeBetweenSpawn < 1f) {
                timeBetweenSpawn = 1f;
            } 
            if (elapsedTime > spawnTime) {
                SpawnObj();
                spawnTime = elapsedTime + timeBetweenSpawn;
            }
        }
    }

    void SpawnObj() {
        int spawnType = UnityEngine.Random.Range(0, 20);

        
        // 45% thorns
        if (spawnType <= 8) {                               
            spawnInd = UnityEngine.Random.Range(thornsMinInd, thornsMaxInd + 1);
        } 
        else if (spawnType <= 18) {  // 50% chance carrots                              
            spawnInd = UnityEngine.Random.Range(carrotsMinInd, carrotsMaxInd + 1);
        } else { // 5% chance power ups
            spawnInd = UnityEngine.Random.Range(powersMinInd, powersMaxInd + 1);
        }

        /*
        // 40% chance thorns
        if (spawnType <= 8) {                               
            spawnInd = UnityEngine.Random.Range(thornsMinInd, thornsMaxInd + 1);
        } 
        else if (spawnType <= 17) {  // 40% chance carrots                              
            spawnInd = UnityEngine.Random.Range(carrotsMinInd, carrotsMaxInd + 1);
        } else { // 10% chance power ups
            spawnInd = UnityEngine.Random.Range(powersMinInd, powersMaxInd + 1);
        }
        */

        float randomX = UnityEngine.Random.Range(minX, maxX);
        string[] ys = spawnYBounds[spawnInd].Split(",");
        float minY = float.Parse(ys[0]);
        float maxY = float.Parse(ys[1]);

        float randomY;

        // if thorns
        if (spawnInd <= thornsMaxInd) {                                 
            int ySect = UnityEngine.Random.Range(0, 20);
            // 35% chance spawn at bottom
            if (ySect < 7) { 
                randomY = UnityEngine.Random.Range(minY, minY+.8f);
            } else if (ySect < 13) {    // 30% chance spawn at middle
                randomY = UnityEngine.Random.Range(-.4f,.7f);
            } else {    // 35% chance spawn at top
                randomY = UnityEngine.Random.Range(maxY-.8f, maxY+.2f);
            }
        } else {
            randomY = UnityEngine.Random.Range(minY, maxY);
        }

        Instantiate(spawnList[spawnInd], new Vector3(randomX + player.transform.position.x, randomY, 0), transform.rotation);
    }
}
