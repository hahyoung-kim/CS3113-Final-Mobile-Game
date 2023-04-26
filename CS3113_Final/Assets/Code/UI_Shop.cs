using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/* Player Prefs to keep track of

carrots
lvl of power ups
    magnetLvl
    boostLvl
    shieldLvl
    coinMulLvl
if the player owns the trail (act as bool 0 and 1)
    stars
    snow
    blossoms
    rainbow
which trail is equipped (act as bool 0 and 1)
    starsEq
    snowEq
    blossomsEq
    rainbowEq

*/

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
        //PlayerPrefs.DeleteAll();
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
        if (boostLvl < maxLvl){
            boostUI.text = "" + boostCost[boostLvl];
            canBuyBoost = (boostCost[boostLvl] <= carrots);
        }
        else{
            boostUI.text = "max";
            canBuyBoost = false;
        }
        if (shieldLvl < maxLvl){
            shieldUI.text = "" + shieldCost[shieldLvl];
            canBuyShield = (shieldCost[shieldLvl] <= carrots);
        }
        else{
            shieldUI.text = "max";
            canBuyShield = false;
        }
        if (coinMulLvl < maxLvl){
            coinMulUI.text = "" + coinMulCost[coinMulLvl];
            canBuyCoinMul = (coinMulCost[coinMulLvl] <= carrots);
        }
        else{
            coinMulUI.text = "max";
            canBuyCoinMul = false;
        }

        if (magnetLvl == maxLvl || canBuyMag == false){
            magnetB.interactable = false;
        }
        else{
            magnetB.interactable = true;
        }

        if (boostLvl == maxLvl || canBuyBoost == false){
            boostB.interactable = false;
        }
        else{
            boostB.interactable = true;
        }
        
        if (shieldLvl == maxLvl || canBuyShield == false){
            shieldB.interactable = false;
        }
        else{
            shieldB.interactable = true;
        }
        
        if (coinMulLvl == maxLvl || canBuyCoinMul == false){
            coinMulB.interactable = false;
        }
        else{
            coinMulB.interactable = true;
        }
    }

    public void magnetButton(){
        if (canBuyMag && magnetLvl != maxLvl){
            carrots -= magnetCost[magnetLvl];
            PlayerPrefs.SetInt("carrots", carrots);
            PlayerPrefs.SetInt("magnetLvl", magnetLvl+1);
        }
        if (magnetLvl == maxLvl || canBuyMag == false){
            magnetB.interactable = false;
        }
        print(PlayerPrefs.GetInt("magnetLvl", 0));
    }

    public void boostButton(){
        if (canBuyBoost && boostLvl != maxLvl){
            carrots -= boostCost[boostLvl];
            PlayerPrefs.SetInt("carrots", carrots);
            PlayerPrefs.SetInt("boostLvl", boostLvl+1);
        }
        if (boostLvl == maxLvl || canBuyBoost == false){
            boostB.interactable = false;
        }
        print(PlayerPrefs.GetInt("boostLvl", 0));
    }

    public void shieldButton(){
        if (canBuyShield && shieldLvl != maxLvl){
            carrots -= shieldCost[shieldLvl];
            PlayerPrefs.SetInt("carrots", carrots);
            PlayerPrefs.SetInt("shieldLvl", shieldLvl+1);
        }
        if (shieldLvl == maxLvl || canBuyShield == false){
            shieldB.interactable = false;
        }
    }

    public void coinMulButton(){
        if (canBuyCoinMul && coinMulLvl != maxLvl){
            carrots -= coinMulCost[coinMulLvl];
            PlayerPrefs.SetInt("carrots", carrots);
            PlayerPrefs.SetInt("coinMulLvl", coinMulLvl+1);
        }
        if (shieldLvl == maxLvl || canBuyCoinMul == false){
            coinMulB.interactable = false;
        }
    }

    public void menu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void next(){
        SceneManager.LoadScene("Shop2");
    }
}
