using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int totalCoin;
    public int coin = 0;
    public Text coinTxt;
    public Text totalCoinTxt;


    private void Start()
    {
        //PlayerPrefs.DeleteKey("TotalCoin");

    }

    //Set the coin value and total the coin value
    public void SetCoinValue()
    {
        coin = 50;
        totalCoin = PlayerPrefs.GetInt("TotalCoin");
        PlayerPrefs.SetInt("TotalCoin", totalCoin + coin);
        //  coinTxt.text = coin.ToString();
        totalCoinTxt.text = totalCoin.ToString();
        coin = 0;
    }
}
