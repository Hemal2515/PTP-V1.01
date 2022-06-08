using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public static Action MainMenu;
    public static Action GamePlay;
    public static Action GameOver;
    public static Action Setting;
    public static Action Shop;

    public Text ballCountText;

    public Canvas mainMenuCanvas;
    public Canvas gamePlayCanvas;
    public Canvas settingCanvas;
    public Canvas shopCanvas;

    public GameObject bGPanel;
    public GameObject winPanel;
    public GameObject failPanel;
    public GameObject pausePanel;

    

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        MainMenu?.Invoke();
    }
    private void OnEnable()
    {
       // MainMenu += ActiveMainMenu;
    }

   public void ActiveGamePlay()
    {
        GameManager.instances.IsGamePaused = false;
        AudioManager.instances.ButtonClick();
        mainMenuCanvas.enabled = false;
        gamePlayCanvas.enabled = true;
        GamePlay?.Invoke();
    }

   public void ActiveSettingScreen()
    {
        settingCanvas.enabled = true;
    }

   public void BackToMainMenu()
    {
        MainMenu?.Invoke();
        settingCanvas.enabled = false;
        shopCanvas.enabled = false;
        //LevelManager.instaces.DestroyLevel();
        winPanel.SetActive(false);
        failPanel.SetActive(false);
        //gamePlayCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
    }

    public void ActiveWinPanel()
    {
        //bGPanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void ActiveShopScreen()
    {
        mainMenuCanvas.enabled = false;
        shopCanvas.enabled = true;
    }

    public void LevelFail()
    {
        StartCoroutine(ActiveFailPanel());
    }

    IEnumerator ActiveFailPanel()
    {
        yield return new WaitForSeconds(1f);
        // bGPanel.SetActive(false);
        AudioManager.instances.GameOver();
        failPanel.SetActive(true);
    }

    public void ActivePausePanel()
    {
        pausePanel.SetActive(true);

    }

    public void ResumeBtn()
    {
        pausePanel.SetActive(false);
    }
    
}
