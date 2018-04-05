using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GameObject board = Instantiate(Resources.Load("Prefabs/Cell"), Vector3.zero, Quaternion.identity) as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
