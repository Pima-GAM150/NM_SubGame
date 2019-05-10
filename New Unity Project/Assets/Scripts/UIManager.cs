using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

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



        playerObject.QueueForwardCommand();

    }

    public void MoveLeft()
    {
        Debug.Log("Move Left pressed");



        playerObject.QueueLeftCommand();

    }

     public void MoveRight()
    {
        Debug.Log("Move Right pressed");



        playerObject.QueueRightCommand();

    }

    public void SetSail()
    {
        Debug.Log("Move Right pressed");



        playerObject.SetSail();

    }


}
