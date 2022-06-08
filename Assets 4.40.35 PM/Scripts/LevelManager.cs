using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelInfo
{
    public GameObject Level;
    public int colorBallNumber;
    //public int greyBallNumber;
    public List<Transform> grayBallPosition = new List<Transform>();
    public List<int> greyBallNumber = new List<int>();
    public int bombNumber;
    public List<Transform> bombPosition = new List<Transform>();
}

public class LevelManager : MonoBehaviour
{
    public static LevelManager instaces;
    private int startBall = 0;
    private GameObject level;   
    public int currentLevel = 1;
     
    //public List<GameObject> StoreLevel = new List<GameObject>();
   public List<LevelInfo> StoreLevel = new List<LevelInfo>();


    private void OnEnable()
    {
        //UIManager.GamePlay += StartLevel;
    }
    private void OnDisable()
    {
        UIManager.GamePlay -= StartLevel;
    }

    
    void Start()
    {
        if(instaces != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instaces = this;
        }
        //PlayerPrefs.DeleteKey("CurrentLevel");
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        level = Instantiate(StoreLevel[currentLevel].Level);
    }

    public void StartLevel()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        level = Instantiate(StoreLevel[currentLevel].Level);
    }

    public void NextLevel()
    {
        Destroy(level);
        currentLevel += 1;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        UIManager.instance.winPanel.SetActive(false);
        UIManager.instance.bGPanel.SetActive(true);
        UIManager.instance.ballCountText.text = startBall.ToString();
       level = Instantiate(StoreLevel[currentLevel].Level);
    }

    public void RestartLevel()
    {
        Destroy(level);
        UIManager.instance.failPanel.SetActive(false);
        UIManager.instance.bGPanel.SetActive(true);
        UIManager.instance.winPanel.SetActive(false);
        UIManager.instance.ballCountText.text = startBall.ToString();
        level = Instantiate(StoreLevel[currentLevel].Level);
    }

    public void DestroyLevel()
    {
        Destroy(level);
    }
    
}
