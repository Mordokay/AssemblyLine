using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductController : MonoBehaviour {

    ProductElementController[] childrenControllers;
    public bool isComplete;
    int usedCount;
    public int difficultyMultiplier;
    public float difficultySpeed;
    GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        switch (gm.difficulty)
        {
            case GameManager.GameMode.easy:
                difficultySpeed = 0.65f;
                break;
            case GameManager.GameMode.normal:
                difficultySpeed = 0.55f;
                break;
            case GameManager.GameMode.hard:
                difficultySpeed = 0.4f;
                break;
        }
        childrenControllers = GetComponentsInChildren<ProductElementController>();
    }

	void Update () {
        this.transform.Translate(Vector3.right * Time.deltaTime * difficultySpeed);
    }

    public void CheckComplete()
    {
        usedCount = 0;
        isComplete = true;
        foreach (ProductElementController prod in childrenControllers)
        {
            if (!prod.isUsed)
            {
                isComplete = false;
            }
            else
            {
                usedCount += 1;
            }
        }
    }

    public int GetScore()
    {
        if (isComplete)
        {
            return 10 * difficultyMultiplier;
        }
        else
        {
            return ((int)((usedCount * 10.0f / childrenControllers.Length)) - 5) * difficultyMultiplier;
        }
    }
}