using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {
    private enum State {
        UNTOUCHED, TOUCHED, FLAGGED, EXPLODED
    }

    private State state;
    private Material material;
    private GameObject board;
    private bool hasBomb;

	// Use this for initialization
	void Start () {
        state = State.UNTOUCHED;
        material = GetComponent<Renderer>().material;
        hasBomb = false;
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

    public void setHasBomb(bool hasBomb) {
        this.hasBomb = hasBomb;
    }

    private void UpdateLeftClick() {
        switch (state)
        {
            case State.UNTOUCHED:
                if (hasBomb)
                {
                    state = State.EXPLODED;
                }
                else {
                    state = State.TOUCHED;
                }
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
            case State.EXPLODED:
                material.color = Color.red;
                break;
        }
    }
}
