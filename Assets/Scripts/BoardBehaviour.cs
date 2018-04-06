using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour {
    public float separation;
    public int columns;
    public int rows;
    public GameObject cell;
    public GameObject[,] cells;
    public int minesCount;

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
                cells[i, j].GetComponent<CellBehaviour>().board = this; 
            }
        }
        for (int i = 0; i < minesCount; i++) {
            int randColumn = (int) Mathf.Round(Random.Range(0, columns));
            int randRow = (int) Mathf.Round(Random.Range(0, rows));
            if (cells[randColumn, randRow].GetComponent<CellBehaviour>().GetHasBomb()) {
                i--;
            } else {
                cells[randColumn, randRow].GetComponent<CellBehaviour>().SetHasBomb(true);
                for (int j = Mathf.Max(randColumn - 1, 0); j < Mathf.Min(randColumn + 2, columns) ; j++) {
                    for (int k = Mathf.Max(randRow - 1, 0); k < Mathf.Min(randRow + 2, rows); k++) {
                        cells[j, k].GetComponent<CellBehaviour>().nearMinesCount++;
                    }
                }
            }
        }
    }

    public void OnMineExploded() {
        for (int i = 0; i < columns; i++) {
            for (int j = 0; j < rows; j++)
            {
                cells[i,j].GetComponent<CellBehaviour>().Touch();
            }
        }
    }
}
