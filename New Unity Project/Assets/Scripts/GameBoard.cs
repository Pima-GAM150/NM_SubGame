﻿using UnityEditor;
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

    public MineSweeper player;
    public BattleShip escort;

    

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
                if (r == 0 && c == 0)
                {
                    if (player != null)
                    {
                        PlayerControl newPlayer = Instantiate(player, newBoard.transform);
                        newPlayer.SetStartingPosition(r, c);
                        Cell clone = Instantiate(playSpaces[0], newBoard.transform);
                        clone.SetNewLocation((r * 10), (c * 10));
                        board[r, c] = clone;
                    }
                    else
                        Debug.LogError("Player PreFab reference is missing!!!");
                }//        this is the clue and mine placement factor
                else if (c == 0 && r == 7)
                {
                    if (escort != null)
                    {
                        PlayerControl battleship = Instantiate(escort, newBoard.transform);
                        battleship.SetStartingPosition(r*10, c*10);
                        Cell clone = Instantiate(playSpaces[0], newBoard.transform);
                        clone.SetNewLocation((r * 10), (c * 10));
                        board[r, c] = clone;
                    }
                    else
                        Debug.LogError("Player PreFab reference is missing!!!");
                }
                else if ((RandomMathEquation(r,c) && mineCount < totalMines && DiceRoll() == 2))
                {
                    Shadows mineClone = Instantiate(mineShadow, newBoard.transform);
                    mineClone.isMineSpot = true;
                    mineClone.SetNewLocation((r * 10), (c * 10));
                    board[r, c] = mineClone;
                    mineCount++;
                }
                else if ((r == rows - 1) && (c == cols - 1))
                {
                    Cell clone = Instantiate(playSpaces[3], newBoard.transform);
                    clone.SetNewLocation((r * 10), (c * 10));
                    board[r, c] = clone;
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

    public bool RandomMathEquation(int r, int c)
    {
        int dice = Random.Range(1,6);

        if (dice <= 3)
        {
            if ((r + c) % 4 == 0){
                return true;
            }
            else return false;
        }
        else
        {
            if ((r + c) % 3 == 0)
            {
                return true;
            }
            else return false;
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
        int rng = Random.Range(1,6);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (r == 0 && c == 0)
                {
                    if (player != null)
                    {
                        PlayerControl newPlayer = Instantiate(player, newBoard.transform);
                        player.SetStartingPosition(r, c);
                        Cell clone = Instantiate(playSpaces[0], newBoard.transform);
                        clone.SetNewLocation((r * 10), (c * 10));
                        board[r, c] = clone;
                    }
                    else
                        Debug.LogError("Player PreFab reference is missing!!!");
                }
                else if (c == 0 && r == rng)
                {
                    if (escort != null)
                    {
                        PlayerControl battleship = Instantiate(escort, newBoard.transform);
                        battleship.SetStartingPosition(r * 10, c * 10);
                        Cell clone = Instantiate(playSpaces[0], newBoard.transform);
                        clone.SetNewLocation((r * 10), (c * 10));
                        board[r, c] = clone;
                    }
                    else
                        Debug.LogError("BattleShip PreFab reference is missing!!!");
                }
                else if ((r == rows - 1) && (c == cols - 1))
                {
                    Cell clone = Instantiate(playSpaces[3], newBoard.transform);
                    clone.SetNewLocation((r * 10), (c * 10));
                    board[r, c] = clone;
                }
                else if ((RandomMathEquation(r,c) && mineCount < totalMines && DiceRoll() != 2))
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
        int rng = Random.Range(1,100);


        if(rng <= 15)
        {
            rngFloor = playSpaces[1];
        }
        else if(rng <= 75)
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
