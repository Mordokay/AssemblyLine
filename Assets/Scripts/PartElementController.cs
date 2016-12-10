using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartElementController : MonoBehaviour
{
    bool isPlaced = false;
    public bool canPlace;
    public GameObject placementPlace;

    void Update()
    {
        if (isPlaced && placementPlace)
        {
            this.transform.position = placementPlace.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ProductElement")
        {
            if (!coll.gameObject.GetComponent<ProductElementController>().isUsed)
            {
                canPlace = true;
                placementPlace = coll.gameObject;
            }

            //Debug.Log("Collided with the parent: " + coll.gameObject.transform.parent.gameObject.name);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        canPlace = false;
    }

    public void PlaceElement()
    {
        placementPlace.GetComponent<ProductElementController>().isUsed = true;
        isPlaced = true;
        placementPlace.transform.parent.gameObject.GetComponent<ProductController>().CheckComplete();
    }
}
