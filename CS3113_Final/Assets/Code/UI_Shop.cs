using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Shop : MonoBehaviour
{
    private int maxLvl;

     public static int magnet;
     public static int magnetLvl;
     public static int boost;
     public static int boostLvl;
     public static int shield;
     public static int shieldLvl;
     public static int coinMul;
     public static int coinMulLvl;

    void Start()
    {
        magnet = PlayerPrefs.GetInt("magnet", 0);
        magnetLvl = PlayerPrefs.GetInt("magnetLvl", 0);
        boost = PlayerPrefs.GetInt("boost", 0);
        boostLvl = PlayerPrefs.GetInt("boostLvl", 0);
        shield = PlayerPrefs.GetInt("shield", 0);
        shieldLvl = PlayerPrefs.GetInt("shieldLvl", 0);
        coinMul = PlayerPrefs.GetInt("coinMul", 0);
        coinMulLvl = PlayerPrefs.GetInt("coinMulLvl", 0);
    }

    public void magnetButton(){
        if (magnetLvl == 0){
            PlayerPrefs.SetInt("magnet", 1);
            PlayerPrefs.SetInt("magnetLvl", 1);
        }
        else if (magnetLvl <= maxLvl){
            PlayerPrefs.SetInt("magnetLvl", magnetLvl+1);
        }
    }

    public void boostButton(){
        if (boostLvl == 0){
            PlayerPrefs.SetInt("boost", 1);
            PlayerPrefs.SetInt("boostLvl", 1);
        }
        else if (boostLvl <= maxLvl){
            PlayerPrefs.SetInt("boostLvl", boostLvl+1);
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
    }

    public void coinMulButton(){
        if (coinMulLvl == 0){
            PlayerPrefs.SetInt("coinMul", 1);
            PlayerPrefs.SetInt("coinMulLvl", coinMulLvl);
        }
        else if (coinMulLvl <= maxLvl){
            PlayerPrefs.SetInt("coinMulLvl", coinMulLvl+1);
        }
    }
}
