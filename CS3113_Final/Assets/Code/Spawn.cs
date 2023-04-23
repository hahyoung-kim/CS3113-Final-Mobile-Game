using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

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
    public GameObject laserBunnies;

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
    private bool canSpawn = false;
    private ArrayList spawned = new ArrayList(); 
    private bool spawnPower = true;
    private bool prevLaser = false;
    private bool spawning = false;
    private int iterations = 0;
    private bool spawnNonLasers = true;

    // Start is called before the first frame update
    void Start()
    {
        ogTBS = timeBetweenSpawn;
        ogMinX = minX;
        ogMaxX = maxX;
        startTime = Time.time;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine(WaitSpawn(4));
        StartCoroutine(PowerCooldown(15));
    }

    public IEnumerator WaitSpawn(float secs){
        canSpawn = false;
        yield return new WaitForSeconds(secs);
        canSpawn = true;
    }

    public IEnumerator PowerCooldown(float secs){
        spawnPower = false;
        yield return new WaitForSeconds(secs);
        spawnPower = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.GetLives() > 0 && canSpawn && !_gameManager.IsPaused()) {
            elapsedTime = Time.time - startTime;
            if (elapsedTime >= 1) {
                timeBetweenSpawn = ogTBS - (float)(Math.Log(elapsedTime) * 0.3);
                minX = ogMinX - (float)(Math.Log(player.transform.position.x));
                maxX = ogMaxX - (float)(Math.Log(player.transform.position.x));
            }
            
            if (minX < 12) {
                minX = 12;
            }
            if (maxX < 12) {
                maxX = 12;
            }
            if (timeBetweenSpawn < 0.75f) {
                timeBetweenSpawn = 0.75f;
            } 
            if (elapsedTime > spawnTime && !spawning) {
                StartCoroutine(SpawnObj());
                spawnTime = elapsedTime + timeBetweenSpawn;
            }
        }
    }

    IEnumerator SpawnObj() {
        spawning = true;
        if (player.transform.position.x >= 400 && (player.transform.position.x % 400 <= 150 || iterations > 0) && !_gameManager.HasMagnet() && !_gameManager.IsGhost() && !_gameManager.IsRainbow()) {
            if (!prevLaser) {
                yield return new WaitForSeconds(3);
            }
            if (iterations <= 0) {
                iterations = UnityEngine.Random.Range(0, 5);
            }
            print("it " + iterations);
            SpawnLasers();
            iterations -= 1;
        } else if (spawnNonLasers) {
            if (prevLaser) {
                yield return new WaitForSeconds(3);
            }
            SpawnObsCrts();
        }
        spawning = false;
    }

    IEnumerator WaitNonLasers(float secs) {
        spawnNonLasers = false;
        yield return new WaitForSeconds(secs);
        spawnNonLasers = true;
    }

    void SpawnLasers() {
        StartCoroutine(WaitSpawn(5.5f));
        StartCoroutine(WaitNonLasers(10));
                
        prevLaser = true;
        float[] yCoords = { -3.4f, -2f, -.6f, 0.8f, 2.2f, 3.6f };
        // shuffle y coords to randomly select where bunnies will spawn
        System.Random random = new System.Random();
        yCoords = yCoords.OrderBy(x => random.Next()).ToArray();
        int numLasers = UnityEngine.Random.Range(0, yCoords.Length-1);
        for (int i = 0; i < numLasers; i++) {
            GameObject spawnedLaser = Instantiate(laserBunnies, new Vector3(player.transform.position.x + 3.16f, yCoords[i], -.5f), transform.rotation);
        }
    }

    void SpawnObsCrts() {
        prevLaser = false;
        int spawnType = UnityEngine.Random.Range(0, 20);

        int spawnInd;
        // 5% chance power ups
        if (spawnType <= 0 && spawnPower) {
            if (_gameManager.HasMagnet()) { // if using magnet dont spawn another magnet
                spawnInd = UnityEngine.Random.Range(powersMinInd, powersMaxInd);
            } else if (_gameManager.IsGhost() || _gameManager.IsRainbow()) { // if ghost or rainbow only spawn magnet
                spawnInd = powersMaxInd;
            } else {    // else spawn any power up
                spawnInd = UnityEngine.Random.Range(powersMinInd, powersMaxInd + 1);
            }
            StartCoroutine(PowerCooldown(5));
            
        } else if (spawnType <= 9) {  // 45% chance carrots                              
            spawnInd = UnityEngine.Random.Range(carrotsMinInd, carrotsMaxInd + 1);
        } else {    // 50% chance thorns
            spawnInd = UnityEngine.Random.Range(thornsMinInd, thornsMaxInd + 1);
        }

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

        print(randomX);
        GameObject spawnedPrefab = Instantiate(spawnList[spawnInd], new Vector3(randomX + player.transform.position.x, randomY, -0.5f), transform.rotation);
        spawned.Add(spawnedPrefab);
    }

    public void DeleteObstacles() {
        foreach (GameObject g in spawned) {
            if (g != null && g.gameObject.tag == "Enemy") {
                Destroy(g.gameObject);
            }
        }
    }
}
