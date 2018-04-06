using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {
    private enum State {
        UNTOUCHED, TOUCHED, FLAGGED, EXPLODED
    }

    private State state;
    private Material material;
    public BoardBehaviour board;
    private bool hasBomb = false;
    private int[] positionOnBard = new int[2];
    public int nearMinesCount;

	// Use this for initialization
	void Start () {
        state = State.UNTOUCHED;
        material = GetComponent<Renderer>().material;
    }
	
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

    public void SetHasBomb(bool hasBomb) {
        this.hasBomb = hasBomb;
    }

    public bool GetHasBomb() {
        return hasBomb;
    }

    public int[] GetPositionOnBoard() {
        return positionOnBard;
    }
    public void SetPositionOnBoard(int[] positionOnBard) {
        this.positionOnBard = positionOnBard;
    }

    private void UpdateLeftClick() {
        Touch();
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

    public void Touch() {
        switch (state)
        {
            case State.UNTOUCHED:
                if (hasBomb)
                {
                    state = State.EXPLODED;
                    board.OnMineExploded();
                }
                else {
                    state = State.TOUCHED;
                }
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
                if (nearMinesCount > 0) {
                    material.color = Color.yellow;
                    GameObject number;
                    switch(nearMinesCount) {
                        case 1:
                            number = Instantiate(Resources.Load("Prefabs/one"), gameObject.transform.position, Quaternion.identity) as GameObject;
                            break;
                        case 2:
                            number = Instantiate(Resources.Load("Prefabs/two"), gameObject.transform.position, Quaternion.identity) as GameObject;
                            break;
                        case 3:
                            number = Instantiate(Resources.Load("Prefabs/three"), gameObject.transform.position, Quaternion.identity) as GameObject;
                            break;
                        case 4:
                            number = Instantiate(Resources.Load("Prefabs/four"), gameObject.transform.position, Quaternion.identity) as GameObject;
                            break;
                        case 5:
                            number = Instantiate(Resources.Load("Prefabs/five"), gameObject.transform.position, Quaternion.identity) as GameObject;
                            break;
                        case 6:
                            number = Instantiate(Resources.Load("Prefabs/six"), gameObject.transform.position, Quaternion.identity) as GameObject;
                            break;
                        case 7:
                            number = Instantiate(Resources.Load("Prefabs/seven"), gameObject.transform.position, Quaternion.identity) as GameObject;
                            break;
                        case 8:
                            number = Instantiate(Resources.Load("Prefabs/eight"), gameObject.transform.position, Quaternion.identity) as GameObject;
                            break;
                    }
                } else {
                    material.color = Color.gray;
                    board.OnSafeCellTouched(positionOnBard[0], positionOnBard[1]);
                }
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
