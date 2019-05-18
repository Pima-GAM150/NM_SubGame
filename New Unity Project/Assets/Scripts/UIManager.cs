using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text commandQDisplay;
    public Text battleShipHPLabel;
    public Text mineSweeperHPLabel;
    public Text shipsSavedDisplay;

    bool buttonsActive = true;
    int ships;

    public MineSweeper playerObject;
    public BattleShip objectiveObject;
    public Port goal;


    void OnPlayerSavesShip(Port portCalling)
    {
        ships++;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<MineSweeper>();
        objectiveObject = FindObjectOfType<BattleShip>();

        Port.PlayerSavedAShipEvent += OnPlayerSavesShip;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goal == null)
            goal = FindObjectOfType<Port>();
        
            shipsSavedDisplay.text = " " + ships; 

        if (playerObject == null)
            playerObject = FindObjectOfType<MineSweeper>();

        if (playerObject != null)
            mineSweeperHPLabel.text = playerObject.hitPoints.ToString();


        if (objectiveObject == null)
            objectiveObject = FindObjectOfType<BattleShip>();

        if (objectiveObject != null)
            battleShipHPLabel.text = objectiveObject.hitPoints.ToString();
    }

    public void EnableAndDisableButtons()
    {
        buttonsActive = !buttonsActive;
    }


    public void MoveMSUp()
    {
        Debug.Log("Move Up pressed");


        playerObject.QueueCommand(1);

    }

    public void MoveMSLeft()
    {
        Debug.Log("Move Left pressed");



        playerObject.QueueCommand(2);

    }

     public void MoveMSRight()
    {
        Debug.Log("Move Right pressed");

        playerObject.QueueCommand(3);

    }

    public void MoveBSUp()
    {
        Debug.Log("Move Up pressed");


        objectiveObject.QueueCommand(1);

    }

    public void MoveBSLeft()
    {
        Debug.Log("Move Left pressed");



        objectiveObject.QueueCommand(2);

    }

    public void MoveBSRight()
    {
        Debug.Log("Move Right pressed");

        objectiveObject.QueueCommand(3);

    }

    public void Detonate()
    {
        Debug.Log("Detonate pressed");

        Shadows[] listOfSpots = FindObjectsOfType<Shadows>();

        foreach (Shadows spot in listOfSpots)
        {
            spot.Detonate();
        }


    }

    public void SetSail()
    {
        if (playerObject != null)
            playerObject.ExecuteCommands();

        if (objectiveObject != null)
            objectiveObject.ExecuteCommands();
    }


}
