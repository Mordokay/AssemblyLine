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
        else if (isPlaced && !placementPlace)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ProductElement" && this.tag == "Cube")
        {
            if (!coll.gameObject.GetComponent<ProductElementController>().isUsed)
            {
                canPlace = true;
                placementPlace = coll.gameObject;
            }
        }
        else if (coll.gameObject.tag == "ProductElementDiamond" && this.tag == "Diamond")
        {
            if (!coll.gameObject.GetComponent<ProductElementController>().isUsed)
            {
                canPlace = true;
                placementPlace = coll.gameObject;
            }
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
        GetComponent<ParticleSystem>().Emit(50);
        placementPlace.transform.parent.gameObject.GetComponent<ProductController>().CheckComplete();
    }
}
