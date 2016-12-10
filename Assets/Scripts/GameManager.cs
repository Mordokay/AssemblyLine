using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score = 0;
    public Text scoreText;

	void Update () {
        scoreText.text = "SCORE: " + score;
    }
}
