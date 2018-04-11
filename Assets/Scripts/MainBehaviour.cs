using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution(400, 400, true);
		Screen.fullScreen = false;
        	GameObject board = Instantiate(Resources.Load("Prefabs/Board"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
