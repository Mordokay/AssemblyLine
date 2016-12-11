using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score = 0;
    public Text scoreText;

    enum GameMode
    {
        easy,
        medium,
        hard
    }

	void Update () {
        scoreText.text = "SCORE: \n" + score;
    }
}
