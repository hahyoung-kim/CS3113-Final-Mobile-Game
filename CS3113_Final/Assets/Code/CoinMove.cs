// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CoinMove : MonoBehaviour
// {
//     Coin coinScript;
 
//     void Start(){
//         coinScript = gameObject.GetComponent<Coin>();
//     }

//     void Update(){
//         transform.position = Vector3.MoveTowards(transform.position, coinScript.playerTransform.position, coinScript.moveSpeed * Time.deltaTime);
//     }

//     private void OnTriggerEnter(Collider other){
//         if(other.gameObject.tag == "Player Bubble"){
//             Destroy(gameObject);
//         }
//     }
// }
