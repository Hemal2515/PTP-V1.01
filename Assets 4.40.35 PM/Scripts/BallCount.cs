using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCount : MonoBehaviour
{
   // public BallSpawner ballSpawner;
    private int ballPercentage;
    private int ballCount = 0;
    private Coin coin;
    public bool IsCount = true;
    public int totalBall;

    private void Start()
    {
        coin =GameObject.Find("GamePlay").  GetComponent<Coin>();
        for (int i = 0; i < LevelManager.instaces.StoreLevel[LevelManager.instaces.currentLevel].greyBallNumber.Count; i++)
        {

            totalBall += LevelManager.instaces.StoreLevel[LevelManager.instaces.currentLevel].greyBallNumber[i];
        }
        totalBall += LevelManager.instaces.StoreLevel[LevelManager.instaces.currentLevel].colorBallNumber;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ColorBall") 
        {
            ballCount++;
            AudioManager.instances.GroupBallPop();
            BallCounter();
        }
        if(collision.tag == "GreyBall")
        {
            Destroy(collision.gameObject);
            UIManager.instance.LevelFail();
        }
    }
   public void BallCounter()
    {
        ballPercentage = (ballCount * 100) /totalBall;
        UIManager.instance.ballCountText .text = ballPercentage.ToString();
        
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
