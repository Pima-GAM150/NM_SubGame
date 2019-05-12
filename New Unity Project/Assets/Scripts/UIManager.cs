using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text commandQDisplay;
    public Text playerHitPoints;

    public PlayerControl playerObject;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<PlayerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == null)
            playerObject = FindObjectOfType<PlayerControl>();

        if (playerObject != null)
            playerHitPoints.text = "HP : " + playerObject.hitPoints.ToString();
    }

    public void MoveUp()
    {
        Debug.Log("Move Up pressed");


        playerObject.ToggleForward();

    }

    public void MoveLeft()
    {
        Debug.Log("Move Left pressed");



        playerObject.ToggleLeft();

    }

     public void MoveRight()
    {
        Debug.Log("Move Right pressed");

        playerObject.ToggleRight();

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
