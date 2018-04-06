using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {
    private enum State {
        UNTOUCHED, TOUCHED, FLAGGED
    }

    private State state;
    private Material material;

	// Use this for initialization
	void Start () {
        state = State.UNTOUCHED;
        material = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void OnMouseOver () {
        if (Input.GetMouseButtonDown(0))
        {
            UpdateLeftClick();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            UpdateRightClick();
        }
    }

    private void UpdateLeftClick() {
        switch (state)
        {
            case State.UNTOUCHED:
                state = State.TOUCHED;
                OnStateUpdated();
                break;
        }
    }

    private void UpdateRightClick() {
        switch (state) {
            case State.UNTOUCHED:
                state = State.FLAGGED;
                OnStateUpdated();
                break;
            case State.FLAGGED:
                state = State.UNTOUCHED;
                OnStateUpdated();
                break;
        }
    }

    private void OnStateUpdated() {
        switch (state)
        {
            case State.UNTOUCHED:
                material.color = Color.white;
                break;
            case State.TOUCHED:
                material.color = Color.gray;
                break;
            case State.FLAGGED:
                material.color = Color.blue;
                break;
        }
    }
}
