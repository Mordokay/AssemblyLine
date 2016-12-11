using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : MonoBehaviour {

    float speed;
    PartElementController[] allChildren;
    SpriteRenderer[] allChildrenSprites;
    public bool canPlace;
    public bool isPlaced;

    void Start () {
        //speed = Random.Range(0.5f, 1.0f);
        speed = 0.8f;
        allChildren = GetComponentsInChildren<PartElementController>();
        allChildrenSprites = GetComponentsInChildren<SpriteRenderer>();
    }
	
    public void Place()
    {
        foreach (PartElementController part in allChildren)
        {
            part.PlaceElement();
            
        }
        isPlaced = true;
    }

    public void SetLayer(int order)
    {
        foreach (SpriteRenderer sprite in allChildrenSprites)
        {
            sprite.sortingOrder = order;

        }
    }

    void Update () {
        
        canPlace = true;
        foreach (PartElementController part in allChildren)
        {
            if (!part.canPlace)
            {
                canPlace = false;
                break;
            }
        }

        /*
        if (canPlace || isPlaced)
        {
            foreach (SpriteRenderer part in allChildrenSprites)
            {
                part.color = Color.green;
            }
                
        }
        else
        {
            foreach (SpriteRenderer part in allChildrenSprites)
            {
                part.color = Color.red;
            }
        }
        */

        this.transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
