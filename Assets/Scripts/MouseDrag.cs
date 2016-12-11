using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    Vector3 origPos, curMousePos;
    GameObject part;
    public LayerMask dragLayers;

	void Update () {
        // Make sure the user pressed the mouse down
        if (!Input.GetMouseButtonDown(0))
            return;


        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f, dragLayers);

        if (!hit)
            return;

       
        part = hit.collider.transform.parent.gameObject;
        origPos = part.transform.position;

        part.GetComponent<PartManager>().SetLayer(2);
        StartCoroutine("DragObject");
    }

    IEnumerator DragObject()
    {
        while (Input.GetMouseButton(0))
        {
            Vector3 newMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            part.transform.position = new Vector3(newMousePos.x, newMousePos.y, 0.0f);
            //Debug.Log("Dragging banana");

            yield return 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (part.GetComponent<PartManager>().canPlace)
            {
                part.GetComponent<PartManager>().Place();
            }
            else
            {
                part.transform.position = origPos;
                part.GetComponent<PartManager>().SetLayer(-4);
            }
            part = null;
        }
    }
}
