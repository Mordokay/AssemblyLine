using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score = 0;
    public Text scoreText;
    public Text timeText;
    public Text highscoreText;
    public GameMode difficulty;
    public int highScore;
    public enum GameMode
    {
        easy,
        normal,
        hard
    }

    void Start()
    {
        highScore = 0;
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
        highscoreText.text = "HIGHSCORE: \n" + highScore;
    }
}
