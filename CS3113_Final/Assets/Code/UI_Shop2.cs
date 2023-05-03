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
    public Image carrot1;
    public Image carrot2;
    public Image carrot3;
    public Image carrot4; 
    public Button equip1;
    public Button equip2;
    public Button equip3;
    public Button equip4; 
    public TextMeshProUGUI equipped1;
    public TextMeshProUGUI equipped2;
    public TextMeshProUGUI equipped3;
    public TextMeshProUGUI equipped4; 

    public static int stars = 0;
    public static int snow = 0;
    public static int blossoms = 0;
    public static int rainbow = 0;
    public static int carrots = 0;

    public static int starsEq = 0;
    public static int snowEq = 0;
    public static int blossomsEq = 0;
    public static int rainbowEq = 0;

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

        starsEq = PlayerPrefs.GetInt("starsEq", starsEq);
        snowEq = PlayerPrefs.GetInt("snowEq", snowEq);
        blossomsEq = PlayerPrefs.GetInt("blossomsEq", blossomsEq);
        rainbowEq = PlayerPrefs.GetInt("rainbowEq", rainbowEq);

        //print(carrots);

        coinsUI.text = "" + carrots;
        if (stars < maxLvl){
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

        if (stars == maxLvl && starsEq == 0){
            carrot1.gameObject.SetActive(false);
            starsUI.gameObject.SetActive(false);
            equip1.gameObject.SetActive(true);
            equip1.interactable = true;
        }
        else if (stars == maxLvl && starsEq == 1){
            carrot1.gameObject.SetActive(false);
            starsUI.gameObject.SetActive(false);
            equip1.gameObject.SetActive(true);
            equip1.interactable = false;
            equipped1.text = "equipped";
            equipped2.text = "equip";
            equipped3.text = "equip";
            equipped4.text = "equip";
        }
        else{
            carrot1.gameObject.SetActive(true);
            starsUI.gameObject.SetActive(true);
            equip1.gameObject.SetActive(false);
        }

        if (snow == maxLvl && snowEq == 0){
            carrot2.gameObject.SetActive(false);
            snowUI.gameObject.SetActive(false);
            equip2.gameObject.SetActive(true);
            equip2.interactable = true;
        }
        else if (snow == maxLvl && snowEq == 1){
            carrot2.gameObject.SetActive(false);
            snowUI.gameObject.SetActive(false);
            equip2.gameObject.SetActive(true);
            equip2.interactable = false;
            equipped1.text = "equip";
            equipped2.text = "equipped";
            equipped3.text = "equip";
            equipped4.text = "equip";
        }
        else{
            carrot2.gameObject.SetActive(true);
            snowUI.gameObject.SetActive(true);
            equip2.gameObject.SetActive(false);
        }

        if (blossoms == maxLvl && blossomsEq == 0){
            carrot3.gameObject.SetActive(false);
            blossomsUI.gameObject.SetActive(false);
            equip3.gameObject.SetActive(true);
            equip3.interactable = true;
        }
        else if (blossoms == maxLvl && blossomsEq == 1){
            carrot3.gameObject.SetActive(false);
            blossomsUI.gameObject.SetActive(false);
            equip3.gameObject.SetActive(true);
            equip3.interactable = false;
            equipped1.text = "equip";
            equipped2.text = "equip";
            equipped3.text = "equipped";
            equipped4.text = "equip";
        }
        else{
            carrot3.gameObject.SetActive(true);
            blossomsUI.gameObject.SetActive(true);
            equip3.gameObject.SetActive(false);
        }

        if (rainbow == maxLvl && rainbowEq == 0){
            carrot4.gameObject.SetActive(false);
            rainbowUI.gameObject.SetActive(false);
            equip4.gameObject.SetActive(true);
            equip4.interactable = true;
        }
        else if (rainbow == maxLvl && rainbowEq == 1){
            carrot4.gameObject.SetActive(false);
            rainbowUI.gameObject.SetActive(false);
            equip4.gameObject.SetActive(true);
            equip4.interactable = false;
            equipped1.text = "equip";
            equipped2.text = "equip";
            equipped3.text = "equip";
            equipped4.text = "equipped";
        }
        else{
            carrot4.gameObject.SetActive(true);
            rainbowUI.gameObject.SetActive(true);
            equip4.gameObject.SetActive(false);
        }
    }

    public void starsButton(){
        if (canBuyStars && stars < maxLvl){
            carrots -= starsCost;
            PlayerPrefs.SetInt("carrots", carrots);
            PlayerPrefs.SetInt("stars", 1);
        }
        carrot1.gameObject.SetActive(false);
        starsUI.gameObject.SetActive(false);
        equip1.gameObject.SetActive(true);
    }

    public void equip1Button(){
        if (starsEq == 0){
            PlayerPrefs.SetInt("starsEq", 1);
            PlayerPrefs.SetInt("snowEq", 0);
            PlayerPrefs.SetInt("blossomsEq", 0);
            PlayerPrefs.SetInt("rainbowEq", 0);
            equip1.interactable = false;
            equip2.interactable = true;
            equip3.interactable = true;
            equip4.interactable = true;
            equipped1.text = "equipped";
            equipped2.text = "equip";
            equipped3.text = "equip";
            equipped4.text = "equip";
            print("equipped");
        }
    }

    public void snowButton(){
        if (canBuySnow && snow < maxLvl){
            carrots -= snowCost;
            PlayerPrefs.SetInt("carrots", carrots);
            PlayerPrefs.SetInt("snow", 1);
        }
        carrot2.gameObject.SetActive(false);
        snowUI.gameObject.SetActive(false);
        equip2.gameObject.SetActive(true);
    }

    public void equip2Button(){
        if (snowEq == 0){
            PlayerPrefs.SetInt("starsEq", 0);
            PlayerPrefs.SetInt("snowEq", 1);
            PlayerPrefs.SetInt("blossomsEq", 0);
            PlayerPrefs.SetInt("rainbowEq", 0);
            equip1.interactable = true;
            equip2.interactable = false;
            equip3.interactable = true;
            equip4.interactable = true;
            equipped1.text = "equip";
            equipped2.text = "equipped";
            equipped3.text = "equip";
            equipped4.text = "equip";
        }
    }

    public void blossomsButton(){
        if (canBuyBlossoms && blossoms < maxLvl){
            carrots -= blossomsCost;
            PlayerPrefs.SetInt("carrots", carrots);
            PlayerPrefs.SetInt("blossoms", 1);
        }
        carrot3.gameObject.SetActive(false);
        blossomsUI.gameObject.SetActive(false);
        equip3.gameObject.SetActive(true);
    }

    public void equip3Button(){
        if (blossomsEq == 0){
            PlayerPrefs.SetInt("starsEq", 0);
            PlayerPrefs.SetInt("snowEq", 0);
            PlayerPrefs.SetInt("blossomsEq", 1);
            PlayerPrefs.SetInt("rainbowEq", 0);
            equip1.interactable = true;
            equip2.interactable = true;
            equip3.interactable = false;
            equip4.interactable = true;
            equipped1.text = "equip";
            equipped2.text = "equip";
            equipped3.text = "equipped";
            equipped4.text = "equip";
        }
    }

    public void rainbowButton(){
        if (canBuyRainbow && rainbow < maxLvl){
            carrots -= rainbowCost;
            PlayerPrefs.SetInt("carrots", carrots);
            PlayerPrefs.SetInt("rainbow", 1);
        }
        carrot4.gameObject.SetActive(false);
        rainbowUI.gameObject.SetActive(false);
        equip4.gameObject.SetActive(true);
    }

    public void equip4Button(){
        if (rainbowEq == 0){
            PlayerPrefs.SetInt("starsEq", 0);
            PlayerPrefs.SetInt("snowEq", 0);
            PlayerPrefs.SetInt("blossomsEq", 0);
            PlayerPrefs.SetInt("rainbowEq", 1);
            equip1.interactable = true;
            equip2.interactable = true;
            equip3.interactable = true;
            equip4.interactable = false;
            equipped1.text = "equip";
            equipped2.text = "equip";
            equipped3.text = "equip";
            equipped4.text = "equipped";
        }
    }

    public void back(){
        SceneManager.LoadScene("Shop");
    }

    public void play(){
        SceneManager.LoadScene("Level1");
    }
}
