using UnityEditor;
using UnityEngine;

public class GameBoard : MonoBehaviour
{

    public int rows;
    public int cols;
    public Cell playspace;
    public Cell[,] board;

    

    public void CreateBoard()
    {
        board = new Cell[rows, cols];
        GameObject newBoard = new GameObject("Game Board");

        for(int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Cell clone = Instantiate(playspace, newBoard.transform);
                clone.SetNewLocation((r*10),(c*10));
                board[r, c] = clone;

            }

        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
