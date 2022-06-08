using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sprite muteImage;
    public Sprite SoundImage;
    public Button button;
    public bool IsSoundOn = false;

    public static AudioManager instances;
    public AudioSource audioSource;

    public AudioClip bombBlast;
    public AudioClip buttonClick;
    public AudioClip gameOver;
    public AudioClip groupBallPop;
    public AudioClip halfLevelComplete;
    public AudioClip levelComplete;
    public AudioClip pullThePin;
    public AudioClip singleBallPop;

    // Start is called before the first frame update
    void Start()
    {
        if (instances != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instances = this;
        }
    }

    public void OnButttonClick()
    {
        if(!IsSoundOn)
        {
            audioSource.mute = false;
            button.image.sprite = SoundImage;
            IsSoundOn = true;
        }
        else
        {
            IsSoundOn = false;
            audioSource.mute = true;
            button.image.sprite = muteImage;
        }
    }

    public void BombBlast()
    {
        audioSource.PlayOneShot(bombBlast);
    }

    public void ButtonClick()
    {
        audioSource.PlayOneShot(buttonClick);
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }

    public void GroupBallPop()
    {
        audioSource.PlayOneShot(groupBallPop);
    }

    public void HalfLevelComplete()
    {
        audioSource.PlayOneShot(halfLevelComplete);
    }

    public void LevelComplete()
    {
        audioSource.PlayOneShot(levelComplete);
    }

    public void PullThePin()
    {
        audioSource.PlayOneShot(pullThePin);
    }

    public void SingleBallPop()
    {
        audioSource.PlayOneShot(singleBallPop);
    }
}
