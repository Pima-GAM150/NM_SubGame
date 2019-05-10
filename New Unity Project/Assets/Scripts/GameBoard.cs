using UnityEditor;
using UnityEngine;

public class GameBoard : MonoBehaviour
{

    public int rows;
    public int cols;
    public Cell[] playspace;
    public Cell[,] board;

    public PlayerControl player;

    

    public void CreateBoard()
    {
        board = new Cell[rows, cols];
        GameObject newBoard = new GameObject("Game Board");

        for(int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (r == 0 && c == 0)
                {
                    if (player != null)
                    {
                        PlayerControl newPlayer = Instantiate(player, newBoard.transform);
                        player.SetStartingPosition(r, c);
                    }
                    else
                        Debug.LogError("Player PreFab reference is missing!!!");
                }
                Cell randomGridPiece = PickRandomCell();
                Cell clone = Instantiate(randomGridPiece, newBoard.transform);
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

    Cell PickRandomCell()
    {
        Cell rngFloor;
        int rng = Random.Range(1,12);

        if (rng <= 2)
        {
            rngFloor = playspace[1];
        }
        else
        {
            rngFloor = playspace[0];
        }

        return rngFloor;
    }

}
