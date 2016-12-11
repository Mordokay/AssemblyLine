using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleColorAnimation : MonoBehaviour {

    public float secondsTochange;
    float time = 0.0f;
    public Color[] myColors;

    void Start()
    {
        this.GetComponent<SpriteRenderer>().color = myColors[Random.Range(0, myColors.Length)];
    }
    void Update()
    {
        time += Time.deltaTime;

        if (time > secondsTochange)
        {
            time = 0.0f;
            this.GetComponent<SpriteRenderer>().color = myColors[Random.Range(0, myColors.Length)];
        }
    }
}
