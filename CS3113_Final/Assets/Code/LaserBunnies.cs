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
    AudioSource _audioSource;
    public AudioClip chargeSound;
    public AudioClip laserSound;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        transform.SetParent(_gameManager.transform);
        _audioSource = GetComponent<AudioSource>();
        waves.SetActive(false);
        laser.SetActive(false);
        StartCoroutine(Activate());
    }

    IEnumerator Activate() {
        yield return new WaitForSeconds(0.5f);
        waves.SetActive(true);
        _audioSource.PlayOneShot(chargeSound);
        yield return new WaitForSeconds(2.5f);
        waves.SetActive(false);
        laser.SetActive(true);
        _audioSource.PlayOneShot(laserSound);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
