using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    private float ogSpd;
    public GameObject player;

    void Start() {
        ogSpd = cameraSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<GameManager>().GetLives() > 0 && !GetComponent<GameManager>().IsPaused()) {
            if (GetComponent<GameManager>().IsRainbow()) {
                cameraSpeed = ogSpd + (float) (Math.Log(player.transform.position.x) * 5);
                transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
            } else {
                cameraSpeed = ogSpd + (float) (Math.Log(player.transform.position.x) * 1.1);
                transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
            }
            
        }
        
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    private float ogSpd;
    public GameObject player;
    private float startTime;
    private float elapsedTime;

    void Start() {
        ogSpd = cameraSpeed;
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime = Time.time - startTime;
        if (elapsedTime >= 1) {
            cameraSpeed = ogSpd + (float) (Math.Log(elapsedTime) * 1.1);
        }
        print("spd " + cameraSpeed);
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}

*/