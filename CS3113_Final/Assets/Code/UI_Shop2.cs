using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UI_Shop2 : MonoBehaviour
{
    private int maxLvl = 1;
    public TextMeshProUGUI coinsUI;
    public Button starsB;
    public Button snowB;
    public Button blossomsB;
    public Button rainbowB; 
    public TextMeshProUGUI starsUI;
    public TextMeshProUGUI snowUI;
    public TextMeshProUGUI blossomsUI;
    public TextMeshProUGUI rainbowUI; 

    public static int stars = 0;
    public static int snow = 0;
    public static int blossoms = 0;
    public static int rainbow = 0;
    public static int carrots = 0;
    bool canBuyStars;
    bool canBuySnow;
    bool canBuyBlossoms;
    bool canBuyRainbow;

    private int starsCost = 250;
    private int snowCost = 500;
    private int blossomsCost = 750;
    private int rainbowCost = 1000;

    void Start(){
        // PlayerPrefs.DeleteAll();
    }

    public void FixedUpdate(){
        stars = PlayerPrefs.GetInt("stars", stars);
        snow = PlayerPrefs.GetInt("snow", snow);
        blossoms = PlayerPrefs.GetInt("blossoms", blossoms);
        rainbow = PlayerPrefs.GetInt("rainbow", rainbow);
        carrots = PlayerPrefs.GetInt("carrots", carrots);

        coinsUI.text = "" + carrots;
        if (stars < 5){
            starsUI.text = "" + starsCost;
            canBuyStars = (starsCost <= carrots);
        }
        else{
            starsUI.text = "max";
            canBuyStars = false;
        }
        if (snow < maxLvl){
            snowUI.text = "" + snowCost;
            canBuySnow = (snowCost <= carrots);
        }
        else{
            snowUI.text = "max";
            canBuySnow = false;
        }
        if (blossoms < maxLvl){
            blossomsUI.text = "" + blossomsCost;
            canBuyBlossoms = (blossomsCost <= carrots);
        }
        else{
            blossomsUI.text = "max";
            canBuyBlossoms = false;
        }
        if (rainbow < maxLvl){
            rainbowUI.text = "" + rainbowCost;
            canBuyRainbow = (rainbowCost <= carrots);
        }
        else{
            rainbowUI.text = "max";
            canBuyRainbow = false;
        }

        if (stars == maxLvl || canBuyStars == false){
            starsB.interactable = false;
        }
        else{
            starsB.interactable = true;
        }

        if (snow == maxLvl || canBuySnow == false){
            snowB.interactable = false;
        }
        else{
            snowB.interactable = true;
        }
        
        if (blossoms == maxLvl || canBuyBlossoms == false){
            blossomsB.interactable = false;
        }
        else{
            blossomsB.interactable = true;
        }
        
        if (rainbow == maxLvl || canBuyRainbow == false){
            rainbowB.interactable = false;
        }
        else{
            rainbowB.interactable = true;
        }
    }

    public void back(){
        SceneManager.LoadScene("Shop");
    }

    public void play(){
        SceneManager.LoadScene("Level1");
    }
}
