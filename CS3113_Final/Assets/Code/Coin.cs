using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 17f;

    void Start(){
      playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update(){
      if (PublicVars.magnetCollider && Vector3.Distance(playerTransform.position, transform.position) < 4){
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
      }
    }
}
