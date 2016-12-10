using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyLineController : MonoBehaviour {

    public Transform spawnPos;
    float time;
    public GameObject[] products;
    public float timeBetweenSpawns;

    void Start () {
        timeBetweenSpawns = 20.0f;

        time = 0.0f;
        GameObject myProduct = Instantiate(products[Random.Range(0, products.Length)]) as GameObject;
        myProduct.transform.position = spawnPos.position;
    }
	
	void Update () {
        time += Time.deltaTime;
        if (time > timeBetweenSpawns)
        {
            time = 0.0f;
            GameObject myProduct = Instantiate(products[Random.Range(0, products.Length)]) as GameObject;
            myProduct.transform.position = spawnPos.position;
        }
    }
}