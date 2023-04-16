using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Shop : MonoBehaviour
{
    private int maxLvl;

     public static int magnet = 0;
     public static int magnetLvl = 0;
     public static int boost = 0;
     public static int boostLvl = 0;
     public static int shield = 0;
     public static int shieldLvl = 0;
     public static int coinMul = 0;
     public static int coinMulLvl = 0;

    void Start()
    {
        magnet = PlayerPrefs.GetInt("magnet", magnet);
        magnetLvl = PlayerPrefs.GetInt("magnetLvl", magnetLvl);
        boost = PlayerPrefs.GetInt("boost", boost);
        boostLvl = PlayerPrefs.GetInt("boostLvl", boostLvl);
        shield = PlayerPrefs.GetInt("shield", shield);
        shieldLvl = PlayerPrefs.GetInt("shieldLvl", shieldLvl);
        coinMul = PlayerPrefs.GetInt("coinMul", coinMul);
        coinMulLvl = PlayerPrefs.GetInt("coinMulLvl", coinMulLvl);
    }

    void Update()
    {
        
    }

    public void magnet(){
        if (magnetLvl == 0){
            PlayerPrefs.SetInt("magnet", 1);
            PlayerPrefs.SetInt("magnetLvl", 1);
        }
        else if (magnetLvl <= maxLvl){
            PlayerPrefs.SetInt("magnetLvl", magnetLvl+1);
        }
        else{
            continue;
        }
    }

    public void boost(){
        if (boostLvl == 0){
            PlayerPrefs.SetInt("boost", 1);
            PlayerPrefs.SetInt("boostLvl", 1);
        }
        else if (boostLvl <= maxLvl){
            PlayerPrefs.SetInt("boostLvl", boostLvl+1);
        }
        else{
            continue;
        }
    }

    public void shield(){
        if (shieldLvl == 0){
            PlayerPrefs.SetInt("shield", 1);
            PlayerPrefs.SetInt("shieldLvl", 1);
        }
        else if (shieldLvl <= maxLvl){
            PlayerPrefs.SetInt("shieldLvl", shieldLvl+1);
        }
        else{
            continue;
        }
    }

    public void coinMul(){
        if (coinMulLvl == 0){
            PlayerPrefs.SetInt("coinMul", 1);
            PlayerPrefs.SetInt("coinMulLvl", coinMulLvl);
        }
        else if (coinMulLvl <= maxLvl){
            PlayerPrefs.SetInt("coinMulLvl", coinMulLvl+1);
        }
        else{
            continue;
        }
    }
}
