using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    float speed = 20f;
    public GameObject player;
    GameManager _gameManager;
    
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        print(Vector3.Distance(player.transform.position, transform.position) + " " +_gameManager.HasMagnet());
        if (_gameManager.GetLives() > 0 && _gameManager.HasMagnet()) {        
            print("go to player");
            // Vector3 displacement = player.transform.position -transform.position;
            // displacement = displacement.normalized;
            // transform.position += (displacement * speed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.time);
        }
    }
}
