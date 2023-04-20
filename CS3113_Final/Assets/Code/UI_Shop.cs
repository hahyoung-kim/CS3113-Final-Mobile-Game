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
     public TextMeshProUGUI magnetUI;
     public TextMeshProUGUI boostUI;
     public TextMeshProUGUI shieldUI;
     public TextMeshProUGUI coinMulUI; 

    //  public static int magnet = 0;
    //  public static int boost = 0;
    //  public static int shield = 0;
    //  public static int coinMul = 0;
     public static int magnetLvl = 0;
     public static int boostLvl = 0;
     public static int shieldLvl = 0;
     public static int coinMulLvl = 0;
     public static int carrots = 0;

     private int[] magnetCost = {50, 100, 175, 275, 400};
     private int[] boostCost = {50, 100, 175, 275, 400};
     private int[] shieldCost = {30, 70, 120, 180, 250};
     private int[] coinMulCost = {75, 125, 200, 300, 425};

    void Start(){
        PlayerPrefs.DeleteAll();
    }

    public void FixedUpdate()
    {
        // magnet = PlayerPrefs.GetInt("magnet", magnet);
        // boost = PlayerPrefs.GetInt("boost", boost);
        // shield = PlayerPrefs.GetInt("shield", shield);
        // coinMul = PlayerPrefs.GetInt("coinMul", coinMul);
        magnetLvl = PlayerPrefs.GetInt("magnetLvl", magnetLvl);
        boostLvl = PlayerPrefs.GetInt("boostLvl", boostLvl);
        shieldLvl = PlayerPrefs.GetInt("shieldLvl", shieldLvl);
        coinMulLvl = PlayerPrefs.GetInt("coinMulLvl", coinMulLvl);
        carrots = PlayerPrefs.GetInt("carrots", carrots);

        coinsUI.text = "" + carrots;
        if (magnetLvl < 5){
            magnetUI.text = "" + magnetCost[magnetLvl];
        }
        else{
            magnetUI.text = "max";
        }
        if (boostLvl < 5){
            boostUI.text = "" + boostCost[boostLvl];
        }
        else{
            boostUI.text = "max";
        }
        if (shieldLvl < 5){
            shieldUI.text = "" + shieldCost[shieldLvl];
        }
        else{
            shieldUI.text = "max";
        }
        if (coinMulLvl < 5){
            coinMulUI.text = "" + coinMulCost[coinMulLvl];
        }
        else{
            coinMulUI.text = "max";
        }

        bool canBuy = (magnetCost[magnetLvl] <= carrots);
        if (magnetLvl == 5 || !canBuy){
            magnetB.interactable = false;
        }
        else{
            magnetB.interactable = true;
        }
        canBuy = (boostCost[boostLvl] <= carrots);
        if (boostLvl == 5 || !canBuy){
            boostB.interactable = false;
        }
        else{
            boostB.interactable = true;
        }
        canBuy = (shieldCost[boostLvl] <= carrots);
        if (boostLvl == 5 || !canBuy){
            shieldB.interactable = false;
        }
        else{
            shieldB.interactable = true;
        }
        canBuy = (coinMulCost[coinMulLvl] <= carrots);
        if (coinMulLvl == 5 || !canBuy){
            coinMulB.interactable = false;
        }
        else{
            coinMulB.interactable = true;
        }
    }

    public void magnetButton(){
        bool canBuy = (magnetCost[magnetLvl] <= carrots);
        if (canBuy && magnetLvl < maxLvl){
            magnetB.interactable = true;
            if (magnetLvl == 0){
            PlayerPrefs.SetInt("magnetLvl", 1);
            }
            else {
                PlayerPrefs.SetInt("magnetLvl", magnetLvl+1);
            }
        }
        if (magnetLvl == 5 || !canBuy){
            magnetB.interactable = false;
        }
        print(PlayerPrefs.GetInt("magnetLvl", 0));
    }

    public void boostButton(){
        if (boostLvl == 0){
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
