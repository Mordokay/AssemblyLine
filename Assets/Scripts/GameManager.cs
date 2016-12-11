using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score = 0;
    public Text scoreText;
    public Text timeText;
    public GameMode difficulty;

    public enum GameMode
    {
        easy,
        normal,
        hard
    }

    void Start()
    {
        switch (PlayerPrefs.GetInt("difficulty")) {
            case 0:
                difficulty = GameMode.easy;
                break;
            case 1:
                difficulty = GameMode.normal;
                break;
            case 2:
                difficulty = GameMode.hard;
                break;
            default:
                break;
        }
    }

	void Update () {
        scoreText.text = "SCORE: \n" + score;
        timeText.text = "TIME: \n" + ((int)Time.timeSinceLevelLoad / 60) + "m " + ((int)Time.timeSinceLevelLoad % 60) + "s";
    }
}
