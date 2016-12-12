using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public GameObject menuCanvas;
    public GameObject difficultyCanvas;
    public GameObject pausePanel;
    public GameObject difficultyPanel;
    public GameObject losePanel;

    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public UnityEngine.UI.Button soundButton;
    public AudioSource soundtrack;
    public bool isSoundOn;

    public bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("pause!!!");
            Pause();
        }
    }

    public void Start()
    {
        isSoundOn = true;

        if (menuCanvas)
            menuCanvas.SetActive(true);
        if(difficultyCanvas)
            difficultyCanvas.SetActive(false);
        if(pausePanel)
            pausePanel.SetActive(false);
        if(difficultyPanel)
            difficultyPanel.SetActive(false);
        if (losePanel)
            losePanel.SetActive(false);
        isPaused = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        menuCanvas.SetActive(true);
        difficultyCanvas.SetActive(false);
    }

    public void SwitchSound()
    {
        if (isSoundOn)
        {
            soundButton.image.overrideSprite = soundOffSprite;
            soundtrack.Stop();
            isSoundOn = false;
        }
        else
        {
            soundButton.image.overrideSprite = soundOnSprite;
            soundtrack.Play();
            isSoundOn = true;
        }
    }


    public void BackPanel()
    {
        pausePanel.SetActive(true);
        difficultyPanel.SetActive(false);
    }

    public void BackToMainScreen()
    {
        SceneManager.LoadScene("mainScene");
        Time.timeScale = 1.0f;
    }

    public void NewGame()
    {
        menuCanvas.SetActive(false);
        difficultyCanvas.SetActive(true);
    }

    public void NewGamePanel()
    {
        pausePanel.SetActive(false);
        difficultyPanel.SetActive(true);
    }

    public void Pause()
    {
        if (!losePanel.activeSelf)
        {
            if (isPaused)
            {
                pausePanel.SetActive(false);
                difficultyPanel.SetActive(false);
                Time.timeScale = 1.0f;
                isPaused = false;
            }
            else
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0.0f;
                isPaused = true;
            }
        }
    }

    public void LoadEasy()
    {
        SceneManager.LoadScene("easyMode");
        PlayerPrefs.SetInt("difficulty", 0);
        Time.timeScale = 1.0f;
    }
    public void LoadNormal()
    {
        SceneManager.LoadScene("normalMode");
        PlayerPrefs.SetInt("difficulty", 1);
        Time.timeScale = 1.0f;

    }
    public void LoadHard()
    {
        SceneManager.LoadScene("hardMode");
        PlayerPrefs.SetInt("difficulty", 2);
        Time.timeScale = 1.0f;
    }
}
