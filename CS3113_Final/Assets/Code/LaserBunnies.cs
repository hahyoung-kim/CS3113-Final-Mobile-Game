using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBunnies : MonoBehaviour
{
    public GameObject leftBun;
    public GameObject rightbun;
    public GameObject waves;
    public GameObject laser;
    GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        transform.SetParent(_gameManager.transform);
        waves.SetActive(false);
        laser.SetActive(false);
        StartCoroutine(Activate());
    }

    IEnumerator Activate() {
        yield return new WaitForSeconds(1f);
        waves.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        waves.SetActive(false);
        laser.SetActive(true);
        print("laser active");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
