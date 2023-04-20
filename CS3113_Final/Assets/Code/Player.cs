using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
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
    public GameObject powerUI;
    public TextMeshProUGUI powerText;
    public Image powerIcon;
    public Sprite[] powerIcons;
    public GameObject spawner;
    RigidbodyConstraints2D ogConst;
 
    bool grounded = false;
    
    private int lasersTouching = 0;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator> ();
        _renderer = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        powerUI.SetActive(false); 
        ogConst = _rigidbody.constraints;
        StartCoroutine(WaitFly());

    }

    void FixedUpdate()
    {
        if (_gameManager.IsPaused()) {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        } else {
            _rigidbody.constraints = ogConst;
        }
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
        if (other.CompareTag("Enemy") && !_gameManager.IsRainbow() && !_gameManager.IsGhost()) {
            _audioSource.PlayOneShot(hurtSound);
            _gameManager.loseLife(1);
            StartCoroutine(FlashRed());
        } else if (other.CompareTag("Carrot")){
            _audioSource.PlayOneShot(pickupSound);
            Destroy(other.gameObject);
            _gameManager.AddCarrots(1);
        } else if (other.CompareTag("Magnet")){
            //_audioSource.PlayOneShot();
            spawner.GetComponent<Spawn>().DeleteObstacles();
            StartCoroutine(ActivateMagnet(10));
            Destroy(other.gameObject);
            powerIcon.sprite = powerIcons[0];
            powerText.text = "Magnet Bunny";
            StartCoroutine(DisplayPowerUI());
        } else if (other.CompareTag("Ghost")){
            //_audioSource.PlayOneShot();
            spawner.GetComponent<Spawn>().DeleteObstacles();
            StartCoroutine(ActivateGhost(10));
            Destroy(other.gameObject);
            powerIcon.sprite = powerIcons[1];
            powerText.text = "Ghost Bunny";
            StartCoroutine(DisplayPowerUI());
        } else if (other.CompareTag("Star")){
            //_audioSource.PlayOneShot();
            spawner.GetComponent<Spawn>().DeleteObstacles();
            StartCoroutine(ActivateRainbow(10));
            Destroy(other.gameObject);
            powerIcon.sprite = powerIcons[2];
            powerText.text = "Rainbow Bunny";
            StartCoroutine(DisplayPowerUI());
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Laser"){
            lasersTouching += 1;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Laser"){
            lasersTouching -= 1;
        }
    }

    IEnumerator ActivateMagnet(float secs) {
        _gameManager.SetMagnet(true);
        if (_gameManager.IsGhost()) {
            // magnet + ghost sprite

        } else if (_gameManager.IsRainbow()) {
            // magnet + rainbow sprite

        } else {
            _renderer.sprite = spriteArray[1]; 
        }
        
        yield return new WaitForSeconds(secs);

        // using a for loop doesnt work so i had to hard code this lol...
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);

        _gameManager.SetMagnet(false);

        if (_gameManager.IsGhost()) {
            // ghost sprite
            _renderer.sprite = spriteArray[2]; 
        } else if (_gameManager.IsRainbow()) {
            // rainbow sprite
            _renderer.sprite = spriteArray[3]; 
        } else {
            // default sprite
           _renderer.sprite = spriteArray[0]; 
        }
    }

    IEnumerator ActivateGhost(float secs) {
        _gameManager.SetGhost(true);
        if (_gameManager.HasMagnet()) {
            // magnet + ghost sprite
            
        } else {
            _renderer.sprite = spriteArray[2]; 
        }
    
        yield return new WaitForSeconds(secs);

        // using a for loop doesnt work so i had to hard code this lol...
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);

        _gameManager.SetGhost(false);

        if (_gameManager.HasMagnet()) {
            // magnet sprite
            _renderer.sprite = spriteArray[1]; 
        } else {
            // default sprite
           _renderer.sprite = spriteArray[0]; 
        }
    }

    IEnumerator ActivateRainbow(float secs) {
        _gameManager.SetRainbow(true);
        if (_gameManager.HasMagnet()) {
            // magnet + rainbow sprite

        } else {
           _renderer.sprite = spriteArray[3]; 
        }
        
        yield return new WaitForSeconds(secs);

        // using a for loop doesnt work so i had to hard code this lol...
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.gray;
        yield return new WaitForSeconds(.2f);
        _renderer.color = Color.white;
        yield return new WaitForSeconds(.2f);

        _gameManager.SetRainbow(false);

        if (_gameManager.HasMagnet()) {
            // magnet sprite
            _renderer.sprite = spriteArray[1]; 
        } else {
            // default sprite
           _renderer.sprite = spriteArray[0]; 
        }
    }

    IEnumerator DisplayPowerUI() {
        powerUI.SetActive(true); 
        _gameManager.SetPause(true);
        yield return new WaitForSeconds(1.5f);
        powerUI.SetActive(false); 
        _gameManager.SetPause(false);
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
        if (_gameManager.LasersActive() && lasersTouching >= 1) {
            _gameManager.loseLife(1);
        }
        grounded = Physics2D.OverlapCircle(feet.position, .3f, whatIsGround);
        for (int i = 0; i < Input.touchCount; ++i){

            Touch touch = Input.GetTouch(i);
            //if (touch.phase == TouchPhase.Began){
            if (touch.phase == TouchPhase.Stationary && canFly && !_gameManager.IsPaused()){
                _rigidbody.AddForce(new Vector3(0, 50, 0), ForceMode2D.Force);
            }
        }
    }
}
