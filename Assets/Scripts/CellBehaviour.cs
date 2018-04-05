using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {
    private enum State {
        UNTOUCHED, TOUCHED, FLAGGED
    }

    private State state;

	// Use this for initialization
	void Start () {
        state = State.UNTOUCHED;
    }
	
	// Update is called once per frame
	void Update () {
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
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case State.TOUCHED:
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case State.FLAGGED:
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
        }
    }
}
