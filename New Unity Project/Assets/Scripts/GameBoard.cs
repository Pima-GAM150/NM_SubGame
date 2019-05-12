using UnityEditor;
using UnityEngine;

public class GameBoard : MonoBehaviour
{

    public int rows;
    public int cols;
    public Cell[] playSpaces;
    public Cell[,] board;
    public Shadows mineShadow;
    public Board currentBoard;

    public int totalMines = 10;
    int mineCount = 0;

    public PlayerControl player;

    

    public void CreateBoard()
    {
        if (currentBoard != null)
            Destroy(currentBoard.gameObject);

        board = new Cell[rows, cols];
        GameObject newBoard = new GameObject("Game Board");
        currentBoard = newBoard.AddComponent<Board>();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if ((r + c) % 3 == 0)
                {
                    Shadows mineClone = Instantiate(mineShadow, newBoard.transform);
                    mineClone.isMineSpot = true;
                    mineClone.SetNewLocation((r * 10), (c * 10));
                }
                Cell randomGridPiece = PickRandomCell();
                Cell clone = Instantiate(randomGridPiece, newBoard.transform);
                clone.SetNewLocation((r * 10), (c * 10));
                board[r, c] = clone;

            }

        }

    }

    public void ResetBoard()
    {
        mineCount = 0;

        if (currentBoard != null)
            Destroy(currentBoard.gameObject);

        board = new Cell[rows, cols];
        GameObject newBoard = new GameObject("Game Board");
        currentBoard = newBoard.AddComponent<Board>();
        

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if ((r + c) % 3 == 0 && mineCount < totalMines && DiceRoll() == 2)
                {
                    Shadows mineClone = Instantiate(mineShadow, newBoard.transform);
                    mineClone.isMineSpot = true;
                    mineClone.SetNewLocation((r * 10), (c * 10));
                    board[r, c] = mineClone;
                    mineCount++;
                }
                else
                {
                    Cell randomGridPiece = PickRandomCell();
                    Cell clone = Instantiate(randomGridPiece, newBoard.transform);
                    clone.SetNewLocation((r * 10), (c * 10));
                    board[r, c] = clone;
                }
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

    void MoveCell(int x, int y)
    {
        Cell currentspot = board[x, y];
        Cell spotBelow = board[x+1, y+1];
        board[x, y] = spotBelow;
        spotBelow = currentspot;
    }


    int DiceRoll()
    {
        int diceResult = Random.Range(1, 3);

        return diceResult;

    }

    Cell PickRandomCell()
    {
        Cell rngFloor;
        int rng = Random.Range(1,20);


        if(rng <= 2)
        {
            rngFloor = playSpaces[1];
        }
        else if(rng <= 10)
        {
            rngFloor = playSpaces[2];//shadows
        }
        else 
        {
            rngFloor = playSpaces[0];
        }

        return rngFloor;
    }

    public Vector3 FindPlayerLocation(PlayerControl playerObject)
    {

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (board[r, c].transform.position == playerObject.transform.position)
                    return board[r, c].transform.position;

            }

        }
        return playerObject.transform.position;
    }

}
