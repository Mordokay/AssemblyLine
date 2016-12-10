using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductController : MonoBehaviour {

    public float productMovementSpeed = 0.8f;
    ProductElementController[] childrenControllers;
    public bool isComplete;
    int usedCount;

    void Start()
    {
        childrenControllers = GetComponentsInChildren<ProductElementController>();
    }

	void Update () {
        this.transform.Translate(Vector3.right * Time.deltaTime * productMovementSpeed);
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
            Debug.Log("Complete!!!");
            return 10;
        }
        else
        {
            Debug.Log("Completed : " + usedCount + " of the Total: " + childrenControllers.Length + 
                "  And are awarded  " + ((int)((usedCount / childrenControllers.Length) * 10) - 5).ToString() + " points");
            return (int)((usedCount * 10.0f / childrenControllers.Length)) - 5;
        }
    }
}