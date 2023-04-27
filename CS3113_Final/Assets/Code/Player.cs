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
    public AudioClip magSound;
    public AudioClip ghostSound;
    public AudioClip rainbowSound;
    public AudioClip boopSound;
    public LayerMask whatIsGround;
    public Transform feet;
    public Transform camera;
    private bool canFly = false;
    public GameObject powerUI;
    public TextMeshProUGUI powerText;
    public Image powerIcon;
    public Sprite[] powerIcons;
    public Image powerBgnd;
    public GameObject spawner;
    RigidbodyConstraints2D ogConst;
    public GameObject coinDetectorObj;
    bool coinDetectorIsActive = false;
    public GameObject starsTrail;
    public GameObject snowTrail;
    public GameObject blossomsTrail;
    public GameObject rainbowTrail;
 
    public ScoreManager carrots;
    bool grounded = false;
    
    public static int magnetLvl = 0;
    public static int boostLvl = 0;
    public static int shieldLvl = 0;
    public static int coinMulLvl = 0;
    public static int starsEq = 0;
    public static int snowEq = 0;
    public static int blossomsEq = 0;
    public static int rainbowEq = 0;

    void Start()
    {
        // uncomment to reset all play prefs
        // PlayerPrefs.DeleteAll();

        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator> ();
        _renderer = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        powerUI.SetActive(false); 
        ogConst = _rigidbody.constraints;
        StartCoroutine(WaitFly());
        coinDetectorObj.SetActive(false);
    
        carrots = gameObject.GetComponent<ScoreManager>();
    }

    void FixedUpdate()
    {
        //print(lasersTouching);
        if (_gameManager.IsPaused()) {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        } else {
            _rigidbody.constraints = ogConst;
        }
        if (Input.GetMouseButton(0) && canFly){
            _rigidbody.AddForce(new Vector3(0, 40, 0), ForceMode2D.Force);
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

        // track power up lvls
        magnetLvl = PlayerPrefs.GetInt("magnetLvl", magnetLvl);
        boostLvl = PlayerPrefs.GetInt("boostLvl", boostLvl);
        shieldLvl = PlayerPrefs.GetInt("shieldLvl", shieldLvl);
        coinMulLvl = PlayerPrefs.GetInt("coinMulLvl", coinMulLvl);

        // equips trails
        starsEq = PlayerPrefs.GetInt("starsEq", starsEq);
        snowEq = PlayerPrefs.GetInt("snowEq", snowEq);
        blossomsEq = PlayerPrefs.GetInt("blossomsEq", blossomsEq);
        rainbowEq = PlayerPrefs.GetInt("rainbowEq", rainbowEq);

        if (starsEq == 1){
            starsTrail.SetActive(true);
            snowTrail.SetActive(false);
            blossomsTrail.SetActive(false);
            rainbowTrail.SetActive(false);
        }
        if (snowEq == 1){
            starsTrail.SetActive(false);
            snowTrail.SetActive(true);
            blossomsTrail.SetActive(false);
            rainbowTrail.SetActive(false);
        }
        if (blossomsEq == 1){
            starsTrail.SetActive(false);
            snowTrail.SetActive(false);
            blossomsTrail.SetActive(true);
            rainbowTrail.SetActive(false);
        }
        if (rainbowEq == 1){
            starsTrail.SetActive(false);
            snowTrail.SetActive(false);
            blossomsTrail.SetActive(false);
            rainbowTrail.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy") && !_gameManager.IsRainbow() && !_gameManager.IsGhost()) {
            _audioSource.PlayOneShot(hurtSound);
            _gameManager.loseLife(1);
            StartCoroutine(FlashRed());
        } else if (other.CompareTag("Carrot")){
            _audioSource.PlayOneShot(pickupSound);
            Destroy(other.gameObject);
            ScoreManager.AddPoints(1);
            _gameManager.AddCarrots(1);
        } else if (other.CompareTag("Magnet")){
            _audioSource.PlayOneShot(magSound);
            Destroy(other.gameObject);
            StartCoroutine(DisplayPowerUI(powerIcons[0], "Magnet Bunny"));
            StartCoroutine(ActivateMagnet(10));
        } else if (other.CompareTag("Ghost")){
            _audioSource.PlayOneShot(ghostSound);
            Destroy(other.gameObject);
            StartCoroutine(DisplayPowerUI(powerIcons[1], "Ghost Bunny"));
            StartCoroutine(ActivateGhost(10));
        } else if (other.CompareTag("Star")){
            _audioSource.PlayOneShot(rainbowSound);
            Destroy(other.gameObject);
            StartCoroutine(DisplayPowerUI(powerIcons[2], "Rainbow Bunny"));
            StartCoroutine(ActivateRainbow(7));
        } else if (other.CompareTag("Laser")){
            _gameManager.loseLife(1);
        }
    }

    IEnumerator ActivateMagnet(float secs) {
        print("done");
        _gameManager.SetMagnet(true);
        _animator.SetBool("magnet", true);

        if (_gameManager.IsGhost()) {
            // magnet + ghost sprite

        } else if (_gameManager.IsRainbow()) {
            // magnet + rainbow sprite

        } else {
            _renderer.sprite = spriteArray[1]; 
        }

        int secondsToAdd = magnetLvl * 2;
        
        coinDetectorObj.SetActive(true);
        coinDetectorIsActive = true;
        PublicVars.magnetCollider = true;
        yield return new WaitForSeconds(secs + secondsToAdd);
        StartCoroutine(Flicker());
        yield return new WaitForSeconds(2f);
        coinDetectorObj.SetActive(false);
        coinDetectorIsActive = false;
        PublicVars.magnetCollider = false;

        _gameManager.SetMagnet(false);
        _animator.SetBool("magnet", false);

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
        _animator.SetBool("ghost", true);

        if (_gameManager.HasMagnet()) {
            // magnet + ghost sprite
            _animator.SetBool("magnetGhost", true);
        } else {
            _renderer.sprite = spriteArray[2]; 
        }

        int secondsToAdd = boostLvl * 2;
    
        yield return new WaitForSeconds(secs + secondsToAdd);
        StartCoroutine(Flicker());
        yield return new WaitForSeconds(2f);
        _gameManager.SetGhost(false);
        _animator.SetBool("ghost", false);
        _animator.SetBool("magnetGhost", false);
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
        _animator.SetBool("rainbow", true);

        yield return new WaitForSeconds(1.5f);
        if (_gameManager.HasMagnet()) {
            // magnet + rainbow sprite
            _animator.SetBool("magnetRainbow", true);
        } else {
           _renderer.sprite = spriteArray[3]; 
        }
        
        int secondsToAdd = shieldLvl * 2;

        yield return new WaitForSeconds(secs + secondsToAdd);

        StartCoroutine(Flicker());
        yield return new WaitForSeconds(2f);
        _gameManager.SetRainbow(false);
        _animator.SetBool("rainbow", false);
        _animator.SetBool("magnetRainbow", false);

        if (_gameManager.HasMagnet()) {
            // magnet sprite
            _renderer.sprite = spriteArray[1]; 
        } else {
            // default sprite
           _renderer.sprite = spriteArray[0]; 
        }
    }

    IEnumerator Flicker() {
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
    }

    IEnumerator DisplayPowerUI(Sprite icon, string power) {
        powerUI.SetActive(true); 
        _gameManager.SetPause(true);
        spawner.GetComponent<Spawn>().DeleteObstacles();

        powerIcon.sprite = icon;
        powerIcon.gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);

        _audioSource.PlayOneShot(boopSound);
        powerBgnd.gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);

        _audioSource.PlayOneShot(boopSound);
        powerText.text = power;
        powerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        
        StartCoroutine(spawner.GetComponent<Spawn>().WaitSpawn(1));
        powerUI.SetActive(false); 
        powerIcon.gameObject.SetActive(false);
        powerBgnd.gameObject.SetActive(false);
        powerText.gameObject.SetActive(false);
        _gameManager.SetPause(false);
    }

    public IEnumerator WaitFly(){
        yield return new WaitForSeconds(3f);
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
            if (touch.phase == TouchPhase.Stationary && canFly && !_gameManager.IsPaused()){
                _rigidbody.AddForce(new Vector3(0, 40, 0), ForceMode2D.Force);
            }
        }
    }
}
