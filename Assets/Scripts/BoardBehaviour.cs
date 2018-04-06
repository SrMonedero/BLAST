using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour {
    public float separation;
    public int columns;
    public int rows;
    public GameObject cell;
    private GameObject[,] cells;
    public int bombCount;

	// Use this for initialization
	void Start ()
    {
        int midColumn = columns / 2;
        int midRow = rows / 2;
        cells = new GameObject[columns, rows];
        for (int i = 0; i < columns; i++) {
            for (int j = 0; j < rows; j++)
            {
                int columnDistance = i - midColumn;
                int rowDistance = j - midRow;
                float xPos = columnDistance + columnDistance * separation + 0.5f + separation/2;
                float yPos = rowDistance + rowDistance * separation + 0.5f + separation / 2;
                cells[i,j] = Instantiate(cell, new Vector3(xPos, yPos, 0), Quaternion.identity) as GameObject;
            }
        }
        for (int i = 0; i < bombCount; i++) {
            int randColumn = (int) Mathf.Round(Random.Range(0, columns));
            int randRow = (int) Mathf.Round(Random.Range(0, rows));
            if (cells[randColumn, randRow].GetComponent<CellBehaviour>().GetHasBomb()) {
                i--;
            } else {
                cells[randColumn, randRow].GetComponent<CellBehaviour>().SetHasBomb(true);
                Debug.Log(randColumn + " " + randRow);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
