using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(coll.gameObject.transform.parent.gameObject);
        
        if (coll.gameObject.transform.parent.gameObject.tag.Equals("Product"))
        {
            gm.score += coll.gameObject.transform.parent.gameObject.GetComponent<ProductController>().GetScore();
        }
        Debug.Log(coll.gameObject.transform.parent.gameObject.name + " Trigger");
    }
}
