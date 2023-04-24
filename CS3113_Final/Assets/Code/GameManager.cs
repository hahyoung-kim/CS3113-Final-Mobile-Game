using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int lives = 1;
    int carrots = 0;
    //public TextMeshProUGUI livesUI;
    //public TextMeshProUGUI reduceHealthUI;
    public string currLvl = "Level1";
    public string gameOverLevel= "Level1";
    //public GameObject explosion;
    //public Image black;
    //public Animator animator;
    AudioSource _audioSource;
    public GameObject player;

    private bool isGh = false;
    private bool hasMag = false;
    private bool isRb = false;
    private bool removeObstacles = false;
    private bool isPaused = false;
    private bool lasersActive = false;

    private void Awake()
    {
        if(GameObject.FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        //reduceHealthUI.gameObject.SetActive(false);  
    }

    private void Start()
    {   
        _audioSource = GetComponent<AudioSource>();
        carrots = PlayerPrefs.GetInt("carrots", 0);
    }

    public void FixedUpdate(){
        PlayerPrefs.SetInt("carrots", carrots);
    }

    public void loseLife(int lostLife){
        lives -= lostLife;

        // scoreUI.text = "score: " + score;

        //livesUI.text = "Lives: " + lives;
        if (lives<=0){
            //StartCoroutine(PlayerDeath());
            PlayerDeath();
        }
        //ReduceHealthText("-" + lostLife, "r");

    }

    public void incrLife(int add){
        lives += add;
        //livesUI.text = "Lives: " + lives;
        //ReduceHealthText("+" + add, "g");
    }

    //IEnumerator PlayerDeath() {
    private void PlayerDeath() {
        //Instantiate(explosion, player.transform.position, Quaternion.identity);
        Destroy(player);
        //animator.SetBool("Fade", true);
        //yield return new WaitUntil(()=>black.color.a==1);
        SceneManager.LoadScene(gameOverLevel);
    }

    // public IEnumerator Fade(){
    //     animator.SetBool("Fade", true);
    //     yield return new WaitUntil(()=>black.color.a==1);
    // }

    public int GetLives() {
        return lives;
    }

    // public void ReduceHealthText(string text, string color){
    //     reduceHealthUI.text = text;
    //     if (color == "g") {
    //         reduceHealthUI.color = Color.green;
    //     } else {
    //         reduceHealthUI.color = Color.red;
    //     }
    //     reduceHealthUI.gameObject.SetActive(true);
    //     Invoke("SetInactive", .5f);
    // }

    // public void SetInactive(){
    //     reduceHealthUI.gameObject.SetActive(false);
    // }

    public void AddCarrots(int num) {
        carrots += num;
    }

    public void SetObsRem(bool b) {
        removeObstacles = b;
    }

    public void SetMagnet(bool b) {
        hasMag = b;
    }

    public void SetGhost(bool b) {
        isGh = b;
    }

    public void SetRainbow(bool b) {
        isRb = b;
    }

    public bool HasMagnet() {
        return hasMag;
    }

    public bool IsGhost() {
        return isGh;
    }

    public bool IsRainbow() {
        return isRb;
    }

    public void SetPause(bool b) {
        isPaused = b;
    }

    public bool IsPaused() {
        return isPaused;
    }

    public bool LasersActivated() {
        return lasersActive;
    }

    public void SetLasers(bool b) {
        lasersActive = b;
    }

    public void Update()
    {
        // quit game is esc
#if !UNITY_WEBGL
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }
}
