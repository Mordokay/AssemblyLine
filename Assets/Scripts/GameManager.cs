using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score = 0;
    public int bestScore;
    public Text scoreText;
    public Text timeText;
    public Text highscoreText;
    public GameMode difficulty;
    public int highScore;

    public GameObject losePanel;
    public Text finalScoreText;
    public bool lostGame;

    public enum GameMode
    {
        easy,
        normal,
        hard
    }

    void Start()
    {
        lostGame = false;
        highScore = 0;
        bestScore = 0;
        switch (PlayerPrefs.GetInt("difficulty")) {
            case 0:
                highScore = PlayerPrefs.GetInt("highscoreEasy");
                difficulty = GameMode.easy;
                break;
            case 1:
                highScore = PlayerPrefs.GetInt("highscoreNormal");
                difficulty = GameMode.normal;
                break;
            case 2:
                highScore = PlayerPrefs.GetInt("highscoreHigh");
                difficulty = GameMode.hard;
                break;
            default:
                break;
        }
    }

	void Update () {
        if(score > bestScore)
        {
            bestScore = score;
        }

        scoreText.text = "SCORE: \n" + score;
        timeText.text = "TIME: \n" + ((int)Time.timeSinceLevelLoad / 60) + "m " + ((int)Time.timeSinceLevelLoad % 60) + "s";
        if (score > highScore)
        {
            highScore = score;
            switch (difficulty)
            {
                case GameMode.easy:
                    PlayerPrefs.SetInt("highscoreEasy", highScore);
                    break;
                case GameMode.normal:
                    PlayerPrefs.SetInt("highscoreNormal", highScore);
                    break;
                case GameMode.hard:
                    PlayerPrefs.SetInt("highscoreHigh", highScore);
                    break;
            }
        }

        if (score < 0)
        {
            lostGame = true;
            losePanel.SetActive(true);
            Time.timeScale = 0.0f;
            finalScoreText.text = "BEST SCORE: " + bestScore;
        }
        highscoreText.text = "HIGHSCORE: \n" + highScore;
    }
}
