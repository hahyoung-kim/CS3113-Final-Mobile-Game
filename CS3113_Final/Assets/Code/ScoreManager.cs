 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using TMPro;
 
 public class ScoreManager : MonoBehaviour {
 
     public static int score;
     public static int highscore;
     public TextMeshProUGUI scoreUI;
     int startingPosX = 0;
     public GameObject player;
 
     void Start()
     {
         score = 0;
         highscore = PlayerPrefs.GetInt ("highscore", highscore);
         scoreUI.text = "score: " + score + "\nhighscore: " + highscore;
         int startingPosX = (int)player.transform.position.x;   
     }

     void FixedUpdate(){
         score = (int)player.transform.position.x - startingPosX;
         scoreUI.text = "score: " + score + "\nhighscore: " + highscore;
         if (score > highscore){
             highscore = score;
             scoreUI.text = "score: " + score + "\nhighscore: " + highscore;
             PlayerPrefs.SetInt ("highscore", highscore);
         }
     }
 
     public static void AddPoints (int pointsToAdd)
     {
         score += pointsToAdd;
     }
 
     public static void Reset()
     {
         score = 0;
     }
 }