using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text commandQDisplay;

    PlayerControl playerObject;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<PlayerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUp()
    {
        Debug.Log("Move Up pressed");

        commandQDisplay.text += "\n Forward";

        playerObject.QueueForwardCommand();

    }

    public void MoveLeft()
    {
        Debug.Log("Move Left pressed");


        commandQDisplay.text += "\n Left";

        playerObject.QueueLeftCommand();

    }

     public void MoveRight()
    {
        Debug.Log("Move Right pressed");


        commandQDisplay.text += "\n Right";

        playerObject.QueueRightCommand();

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
