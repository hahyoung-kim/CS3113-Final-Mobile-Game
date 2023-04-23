using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBunny : MonoBehaviour
{
    public GameObject bunny;
    public GameObject warning;
    GameManager _gameManager;
    AudioSource _audioSource;
    public AudioClip warningSound;
    public AudioClip launchSound;
    private int speed = 25;
    //private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        //_rigidbody = GetComponent<Rigidbody2D>();
        transform.SetParent(_gameManager.transform);
        _audioSource = GetComponent<AudioSource>();
        bunny.SetActive(false);
        warning.SetActive(true);
        StartCoroutine(Activate());
    }

    IEnumerator Activate() {
        _audioSource.PlayOneShot(warningSound);
        yield return new WaitForSeconds(0.2f);
        warning.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        warning.GetComponent<SpriteRenderer>().color = Color.white;
        _audioSource.PlayOneShot(warningSound);
        yield return new WaitForSeconds(0.2f);
        warning.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        warning.GetComponent<SpriteRenderer>().color = Color.white;
        _audioSource.PlayOneShot(warningSound);
        yield return new WaitForSeconds(0.2f);
        warning.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        warning.GetComponent<SpriteRenderer>().color = Color.white;
        _audioSource.PlayOneShot(warningSound);
        yield return new WaitForSeconds(0.2f);
        warning.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(2);      
        warning.SetActive(false);
        bunny.SetActive(true);
        _audioSource.PlayOneShot(launchSound);
        bunny.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed,bunny.GetComponent<Rigidbody2D>().velocity.y);

        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
