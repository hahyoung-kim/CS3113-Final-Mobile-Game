using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UI_Shop : MonoBehaviour
{
     private int maxLvl = 5;
     public TextMeshProUGUI coinsUI;
     public Button magnetB;
     public Button boostB;
     public Button shieldB;
     public Button coinMulB; 

     public static int magnet = 0;
     public static int magnetLvl = 0;
     public static int boost = 0;
     public static int boostLvl = 0;
     public static int shield = 0;
     public static int shieldLvl = 0;
     public static int coinMul = 0;
     public static int coinMulLvl = 0;
     public static int carrots = 0;

    void Start(){
        PlayerPrefs.DeleteAll();
    }

    public void FixedUpdate()
    {
        magnet = PlayerPrefs.GetInt("magnet", magnet);
        magnetLvl = PlayerPrefs.GetInt("magnetLvl", magnetLvl);
        boost = PlayerPrefs.GetInt("boost", boost);
        boostLvl = PlayerPrefs.GetInt("boostLvl", boostLvl);
        shield = PlayerPrefs.GetInt("shield", shield);
        shieldLvl = PlayerPrefs.GetInt("shieldLvl", shieldLvl);
        coinMul = PlayerPrefs.GetInt("coinMul", coinMul);
        coinMulLvl = PlayerPrefs.GetInt("coinMulLvl", coinMulLvl);
        carrots = PlayerPrefs.GetInt("carrots", carrots);
    }

    public void magnetButton(){
        if (magnetLvl == 0){
            PlayerPrefs.SetInt("magnet", 1);
            PlayerPrefs.SetInt("magnetLvl", 1);
        }
        else if (magnetLvl < maxLvl){
            PlayerPrefs.SetInt("magnetLvl", magnetLvl+1);
        }
        if (magnetLvl == 5){
            magnetB.interactable = false;
        }
        print(PlayerPrefs.GetInt("magnetLvl", 0));
    }

    public void boostButton(){
        if (boostLvl == 0){
            PlayerPrefs.SetInt("boost", 1);
            PlayerPrefs.SetInt("boostLvl", 1);
        }
        else if (boostLvl <= maxLvl){
            PlayerPrefs.SetInt("boostLvl", boostLvl+1);
        }
        if (boostLvl == 5){
            boostB.interactable = false;
        }
    }

    public void shieldButton(){
        if (shieldLvl == 0){
            PlayerPrefs.SetInt("shield", 1);
            PlayerPrefs.SetInt("shieldLvl", 1);
        }
        else if (shieldLvl <= maxLvl){
            PlayerPrefs.SetInt("shieldLvl", shieldLvl+1);
        }
        if (shieldLvl == 5){
            shieldB.interactable = false;
        }
    }

    public void coinMulButton(){
        if (coinMulLvl == 0){
            PlayerPrefs.SetInt("coinMul", 1);
            PlayerPrefs.SetInt("coinMulLvl", coinMulLvl);
        }
        else if (coinMulLvl <= maxLvl){
            PlayerPrefs.SetInt("coinMulLvl", coinMulLvl+1);
        }
        if (coinMulLvl == 5){
            coinMulB.interactable = false;
        }
    }

    public void menu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void next(){
        SceneManager.LoadScene("Shop2");
    }

    public void back(){
        SceneManager.LoadScene("Shop");
    }

    public void play(){
        SceneManager.LoadScene("Level1");
    }
}
