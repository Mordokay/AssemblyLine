using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject[] parts;
    float time = 0.0f;
    public float timeIntervalSpawn;
	
	void Update () {
        time += Time.deltaTime;
        if (time > timeIntervalSpawn)
        {
            foreach(Transform point in spawnPoints)
            {
                time = 0.0f;
                GameObject myPart = Instantiate(parts[Random.Range(0, parts.Length)]) as GameObject;
                myPart.transform.position = point.position;
            }
        }
    }
}
