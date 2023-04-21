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
     public static int carrots = 4000;
     bool canBuyMag;
     bool canBuyBoost;
     bool canBuyShield;
     bool canBuyCoinMul;

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
            canBuyMag = (magnetCost[magnetLvl] <= carrots);
        }
        else{
            magnetUI.text = "max";
            canBuyMag = false;
        }
        if (boostLvl < 5){
            boostUI.text = "" + boostCost[boostLvl];
            canBuyBoost = (boostCost[boostLvl] <= carrots);
        }
        else{
            boostUI.text = "max";
            canBuyBoost = false;
        }
        if (shieldLvl < 5){
            shieldUI.text = "" + shieldCost[shieldLvl];
            canBuyShield = (shieldCost[shieldLvl] <= carrots);
        }
        else{
            shieldUI.text = "max";
            canBuyShield = false;
        }
        if (coinMulLvl < 5){
            coinMulUI.text = "" + coinMulCost[coinMulLvl];
            canBuyCoinMul = (coinMulCost[coinMulLvl] <= carrots);
        }
        else{
            coinMulUI.text = "max";
            canBuyCoinMul = false;
        }

        if (magnetLvl == 5 || canBuyMag == false){
            magnetB.interactable = false;
        }
        else{
            magnetB.interactable = true;
        }

        if (boostLvl == 5 || canBuyBoost == false){
            boostB.interactable = false;
        }
        else{
            boostB.interactable = true;
        }
        
        if (shieldLvl == 5 || canBuyShield == false){
            shieldB.interactable = false;
        }
        else{
            shieldB.interactable = true;
        }
        
        if (coinMulLvl == 5 || canBuyCoinMul == false){
            coinMulB.interactable = false;
        }
        else{
            coinMulB.interactable = true;
        }
    }

    public void magnetButton(){
        if (canBuyMag && magnetLvl != 5){
            carrots -= magnetCost[magnetLvl];
            PlayerPrefs.SetInt("magnetLvl", magnetLvl+1);
        }
        if (magnetLvl == 5 || canBuyMag == false){
            magnetB.interactable = false;
        }
        print(PlayerPrefs.GetInt("magnetLvl", 0));
    }

    public void boostButton(){
        if (canBuyBoost && boostLvl != 5){
            carrots -= boostCost[boostLvl];
            PlayerPrefs.SetInt("boostLvl", boostLvl+1);
        }
        if (boostLvl == 5 || canBuyBoost == false){
            boostB.interactable = false;
        }
        print(PlayerPrefs.GetInt("boostLvl", 0));
    }

    public void shieldButton(){
        if (canBuyShield && shieldLvl != 5){
            carrots -= shieldCost[shieldLvl];
            PlayerPrefs.SetInt("shieldLvl", shieldLvl+1);
        }
        if (shieldLvl == 5 || canBuyShield == false){
            shieldB.interactable = false;
        }
    }

    public void coinMulButton(){
        if (canBuyCoinMul && coinMulLvl != 5){
            carrots -= coinMulCost[coinMulLvl];
            PlayerPrefs.SetInt("coinMulLvl", coinMulLvl+1);
        }
        if (shieldLvl == 5 || canBuyCoinMul == false){
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
