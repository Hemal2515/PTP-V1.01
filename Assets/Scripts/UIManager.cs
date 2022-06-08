using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public bool IsWon;

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
    public Canvas upComingLevelCanvas;

    public GameObject bGPanel;
    public GameObject winPanel;
    public GameObject failPanel;
    public GameObject pausePanel;



    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
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
        AudioManager.instances.ButtonClick();
        settingCanvas.enabled = true;
    }

    public void BackToMainMenu()
    {
        MainMenu?.Invoke();
        GameManager.instances.IsGamePaused = true;
        AudioManager.instances.ButtonClick();
        shopCanvas.enabled = false;
        LevelManager.instaces.DestroyLevel();
        LevelManager.instaces.RestartLevel();
        winPanel.SetActive(false);
        failPanel.SetActive(false);
        //gamePlayCanvas.enabled = false;
        upComingLevelCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
    }

    public void ActiveWinPanel()
    {
        GameManager.instances.IsGamePaused = true;
        //bGPanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void ActiveShopScreen()
    {
        AudioManager.instances.ButtonClick();
        mainMenuCanvas.enabled = false;
        shopCanvas.enabled = true;
    }

    public void LevelFail()
    {
        StartCoroutine(ActiveFailPanel());
    }

    IEnumerator ActiveFailPanel()
    {
        GameManager.instances.IsGamePaused = true;
        yield return new WaitForSeconds(1f);
        AudioManager.instances.GameOver();
        failPanel.SetActive(true);
    }

    public void ActivePausePanel()
    {
        GameManager.instances.IsGamePaused = true;
        AudioManager.instances.ButtonClick();
        pausePanel.SetActive(true);

    }

    public void ResumeBtn()
    {
        GameManager.instances.IsGamePaused = false;
        AudioManager.instances.ButtonClick();
        pausePanel.SetActive(false);
    }

    public void SettingToMainMenu()
    {
        AudioManager.instances.ButtonClick();
        settingCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
        shopCanvas.enabled = false;
    }

    public void QuitBtn()
    {
        AudioManager.instances.ButtonClick();
        Application.Quit();
    }

    public void AdvanceLevel()
    {
        upComingLevelCanvas.enabled = true;
    }

    public void OkBtn()
    {
        BackToMainMenu();
    }
}
