using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    public int speed = 3;
    public int jumpForce = 650;
    int bulletSpeed = 600;
    private Rigidbody2D _rigidbody;
    private Animator _animator; 
    private SpriteRenderer _renderer;
    public Sprite[] spriteArray;
    public string currLvl = "Level1";
    GameManager _gameManager;
    AudioSource _audioSource;
    public AudioClip hurtSound;
    public AudioClip pickupSound;
    public LayerMask whatIsGround;
    public Transform feet;
    public Transform camera;
    private bool canFly = false;
    
 
    bool grounded = false;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator> ();
        _renderer = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(WaitFly());

    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && canFly){
            _rigidbody.AddForce(new Vector3(0, 50, 0), ForceMode2D.Force);
        } 
        else if (Input.GetMouseButtonUp(0)){
            //_rigidbody.velocity *= 0.5f;
        }
        if (transform.position.x - camera.position.x <= -3.5f) {
            _rigidbody.velocity = new Vector2(speed,_rigidbody.velocity.y);
        } 
        else if (transform.position.x - camera.position.x >= -2.7f && grounded) {
            _rigidbody.velocity = new Vector2(-speed,_rigidbody.velocity.y);
        }

        // float xScale = transform.localScale.x;
        // if ((xSpeed < 0 && xScale > 0) || (xSpeed > 0 && xScale < 1))
        // {
        //     transform.localScale *= new Vector2(-1,1);
        // }
        // _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            _audioSource.PlayOneShot(hurtSound);
            _gameManager.loseLife(1);
            StartCoroutine(FlashRed());
        } else if (other.CompareTag("Carrot")){
            _audioSource.PlayOneShot(pickupSound);
            Destroy(other.gameObject);
            _gameManager.AddCarrots(1);
        } else if (other.CompareTag("Magnet")){
            //_audioSource.PlayOneShot();
            _renderer.sprite = spriteArray[0]; 
            //_animator.SetBool("Magnet", true);
            Destroy(other.gameObject);
        } else if (other.CompareTag("Ghost")){
            //_audioSource.PlayOneShot();
            _renderer.sprite = spriteArray[1]; 
            //_animator.SetBool("Ghost", true);
            Destroy(other.gameObject);
        } else if (other.CompareTag("Star")){
            //_audioSource.PlayOneShot();
            _renderer.sprite = spriteArray[2]; 
            //_animator.SetBool("Star", true);
            Destroy(other.gameObject);
        }
    }

    public IEnumerator WaitFly(){
        yield return new WaitForSeconds(2.5f);
        canFly = true;
    }

    IEnumerator FlashRed() {
        _renderer.color = Color.red;
        yield return new WaitForSeconds(.1f);
        _renderer.color = Color.white;
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, .3f, whatIsGround);
        for (int i = 0; i < Input.touchCount; ++i){

            Touch touch = Input.GetTouch(i);
            //if (touch.phase == TouchPhase.Began){
            if (touch.phase == TouchPhase.Stationary && canFly){ // did not test yet
                _rigidbody.AddForce(new Vector3(0, 50, 0), ForceMode2D.Force);
            }
        }
    }
}
