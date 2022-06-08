using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCount : MonoBehaviour
{
    public LevelInformation levelInformation;
    private int ballPercentage;
    private int ballCount = 0;
    private Coin coin;
    public bool IsCount = true;
    public int totalBall;

    public AudioClip groupBallClip;
    private void Start()
    {
        //Count all the balls in the game.
        coin = GameObject.Find("GamePlay").GetComponent<Coin>();
        for (int i = 0; i < levelInformation.greyBallNumber.Count; i++)
        {
            totalBall += levelInformation.greyBallNumber[i];
        }
        totalBall += levelInformation.colorBallNumber;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorBall")
        {
            ballCount++;
            AudioManager.instances.GroupBallPop();
            BallCounter();
        }
        if (collision.tag == "GreyBall")
        {
            Destroy(collision.gameObject);
            UIManager.instance.LevelFail();
        }
    }

    //Divede bucket ball in percentage
    public void BallCounter()
    {
        ballPercentage = (ballCount * 100) / totalBall;
        UIManager.instance.ballCountText.text = ballPercentage.ToString();

        Result();
    }

    void Result()
    {
        if (ballCount == totalBall)
        {
            AudioManager.instances.LevelComplete();
            Invoke("ActiveWinPanel", 1f);
        }

    }



    void ActiveWinPanel()
    {
        coin.SetCoinValue();
        UIManager.instance.ActiveWinPanel();
    }


}
