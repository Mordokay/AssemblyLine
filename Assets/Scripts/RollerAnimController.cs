using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerAnimController : MonoBehaviour {
    
    void Start()
    {

    }

	void Update () {

        if(this.transform.localPosition.x >= 0.5f)
        {
            this.transform.localPosition = Vector3.zero;
        }
        this.transform.Translate(Vector3.right * Time.deltaTime * 0.4f);
	}
}
