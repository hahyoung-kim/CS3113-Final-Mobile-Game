using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject coinDetectorObj;

    void Start(){
        coinDetectorObj.SetActive(false);
        print("did");
    }

    void OnTriggerEnter(Collider other){
      print("hit");
    }

    void OnCollisionEnter2D(Collision2D other){
          StartCoroutine(ActivateCoin());
          print("started");
    }

    IEnumerator ActivateCoin(){
        coinDetectorObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        coinDetectorObj.SetActive(false);
    }
}
