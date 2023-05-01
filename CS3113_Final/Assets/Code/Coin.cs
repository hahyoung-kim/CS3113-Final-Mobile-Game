using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 17f;
    public GameObject player;
    GameManager _gameManager;

    void Start(){
      playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
      _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update(){
      if (_gameManager.GetLives() > 0 && PublicVars.magnetCollider && _gameManager.HasMagnet() && Vector3.Distance(playerTransform.position, transform.position) < 4){
        if (_gameManager.IsRainbow()) {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * 5 * Time.deltaTime);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
        
      }
    }
}
