using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text commandQDisplay;
    public Text battleShipHPLabel;
    public Text mineSweeperHPLabel;

    public MineSweeper playerObject;
    public BattleShip objectiveObject;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<MineSweeper>();
        objectiveObject = FindObjectOfType<BattleShip>();


        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == null)
            playerObject = FindObjectOfType<MineSweeper>();

        if (playerObject != null)
            mineSweeperHPLabel.text = playerObject.hitPoints.ToString();


        if (objectiveObject == null)
            objectiveObject = FindObjectOfType<BattleShip>();

        if (objectiveObject != null)
            battleShipHPLabel.text = objectiveObject.hitPoints.ToString();
    }

    public void MoveMSUp()
    {
        Debug.Log("Move Up pressed");


        playerObject.ToggleForward();

    }

    public void MoveMSLeft()
    {
        Debug.Log("Move Left pressed");



        playerObject.ToggleLeft();

    }

     public void MoveMSRight()
    {
        Debug.Log("Move Right pressed");

        playerObject.ToggleRight();

    }

    public void MoveBSUp()
    {
        Debug.Log("Move Up pressed");


        objectiveObject.ToggleForward();

    }

    public void MoveBSLeft()
    {
        Debug.Log("Move Left pressed");



        objectiveObject.ToggleLeft();

    }

    public void MoveBSRight()
    {
        Debug.Log("Move Right pressed");

        objectiveObject.ToggleRight();

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


}
