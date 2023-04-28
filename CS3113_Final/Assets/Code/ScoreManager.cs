 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using TMPro;
 
 public class ScoreManager : MonoBehaviour {
 
     public static int score;
     public static int highscore = 0;
     public static int carrots = 0;
     public TextMeshProUGUI scoreUI;
     int startingPosX = 0;
     public GameObject player;
 
     void Start()
     {
         score = 0;
         carrots = 0;
         highscore = PlayerPrefs.GetInt ("highscore", highscore);
         scoreUI.text = "score: " + score + "\nhighscore: " + highscore + "\ncarrots: " + carrots;
         int startingPosX = (int)player.transform.position.x;   
     }

     void FixedUpdate(){
        if (GetComponent<GameManager>().GetLives() > 0) {
            score = (int)player.transform.position.x - startingPosX;
            scoreUI.text = "score: " + score + "\nhighscore: " + highscore + "\ncarrots: " + carrots;
            if (score > highscore){
                highscore = score;
                scoreUI.text = "score: " + score + "\nhighscore: " + highscore + "\ncarrots: " + carrots;
                PlayerPrefs.SetInt ("highscore", highscore);
            }
        }
     }
 
     public static void AddPoints (int pointsToAdd)
     {
        carrots += pointsToAdd;
     }
 
     public static void Reset()
     {
         carrots = 0;
     }
 }