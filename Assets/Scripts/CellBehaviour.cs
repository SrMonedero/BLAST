using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (Input.GetMouseButton(1))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
