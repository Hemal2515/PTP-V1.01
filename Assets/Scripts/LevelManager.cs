using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instaces;
    private int startBall = 0;
    private GameObject level;
    public int currentLevel = 0;

    public List<GameObject> LevelList = new List<GameObject>();


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
        if (instaces != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instaces = this;
        }
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        level = Instantiate(LevelList[currentLevel], this.transform);
    }

    public void StartLevel()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        level = Instantiate(LevelList[currentLevel]);
    }

    //Start NextLevel
    public void NextLevel()
    {
        Destroy(level);
        GameManager.instances.IsGamePaused = false;
        AudioManager.instances.ButtonClick();
        UIManager.instance.winPanel.SetActive(false);
        UIManager.instance.bGPanel.SetActive(true);
        UIManager.instance.ballCountText.text = startBall.ToString();
        currentLevel += 1;

        if (currentLevel >= LevelList.Count)
        {
            UIManager.instance.AdvanceLevel();
            currentLevel = 0;
        }

        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        level = Instantiate(LevelList[currentLevel], this.transform) as GameObject;

    }

    //Restart Level
    public void RestartLevel()
    {
        Destroy(level);
        GameManager.instances.IsGamePaused = false;
        AudioManager.instances.ButtonClick();
        UIManager.instance.failPanel.SetActive(false);
        UIManager.instance.bGPanel.SetActive(true);
        UIManager.instance.winPanel.SetActive(false);
        UIManager.instance.ballCountText.text = startBall.ToString();
        level = Instantiate(LevelList[currentLevel]);
    }

    public void DestroyLevel()
    {
        Destroy(level);
    }

}
