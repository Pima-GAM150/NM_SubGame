using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    public float moveSpeed;

    public Vector3 currentPos;
    public Vector3 forwardDestination;
    public Transform rightDestination;
    public Transform leftDestination;
    public float distance;
    public bool isMoving = false;
    bool buttonsActive;

    float startTime;

    //so player will click buttons to fill the cammand list, the int will dictate the movement type.
    public List<int> commandQueue = new List<int>();

    public GameBoard gameBoard;

    private int step = 10;


    public enum StatePlayer { dead = 0, alive = 1}
    public StatePlayer playerState;
    

    void Start()
    {
        gameBoard = FindObjectOfType<GameBoard>();
        currentPos = this.transform.position;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            buttonsActive = true;
        }
        if (isMoving)
        {
            MoveShip();
        }
    }

    private void MoveShip()
    {
        foreach (int command in commandQueue)
        {
            //float waitTimer = 10;
            //while (waitTimer > 0)
            //{
            //    waitTimer -= Time.deltaTime;
            //    Debug.Log(waitTimer);
            //}
            //currentPos = this.transform.position;
            if (command == 1)
                MoveForward();
            if (command == 2)
                MoveLeft();
            if (command == 3)
                MoveRight();

            //waitTimer = 10;
        }

        isMoving = false;
        commandQueue.Clear();
    }

    public void SetStartingPosition(int startingRow, int startingCol)
    {
        this.transform.position = new Vector3(transform.position.x + startingRow, transform.position.y, transform.position.z + startingCol);
        
    }

    //these are the button seletion methods

    public void QueueForwardCommand()
    {
        if(buttonsActive)
            commandQueue.Add(1);
    }
    public void QueueLeftCommand()
    {
        if (buttonsActive)
            commandQueue.Add(2);
    }

    public void QueueRightCommand()
    {
        if (buttonsActive)
            commandQueue.Add(3);
    }


    public void SetSail()
    {
        isMoving = !isMoving;
    }


    //these are the command methods
    public void MoveForward()
    {
        //this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + step);

        startTime = Time.time;

        distance = Vector3.Distance(currentPos, forwardDestination);


        //Debug.Log("Moving forward");

        //    float distanceCovered = (Time.time - startTime) * moveSpeed;
        //    float fracJourney = distanceCovered / distance;
        if (Vector3.Distance(currentPos, forwardDestination) > .5)
        {
            forwardDestination = new Vector3(transform.position.x, transform.position.y, transform.position.z + step);

            transform.position = Vector3.MoveTowards(transform.position, forwardDestination, moveSpeed * Time.deltaTime);
        }
    }
    public void MoveLeft()
    {
        this.transform.position = new Vector3(transform.position.x-step, transform.position.y, transform.position.z);
        
        //currentPos = this.transform.position;
        //startTime = Time.time;
        //distance = Vector3.Distance(currentPos, forwardDestination);
        //float distanceCovered = (Time.time - startTime) * moveSpeed;
        //float fracJourney = distanceCovered / distance;

        //Debug.Log("Moving left");


        //forwardDestination = new Vector3(transform.position.x - step, transform.position.y, transform.position.z);

        //transform.position = Vector3.Lerp(currentPos, forwardDestination, fracJourney);
    }

    public void MoveRight()
    {
        this.transform.position = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);

        //currentPos = this.transform.position;
        //startTime = Time.time;
        //distance = Vector3.Distance(currentPos, forwardDestination);
        //float distanceCovered = (Time.time - startTime) * moveSpeed;
        //float fracJourney = distanceCovered / distance;

        //Debug.Log("Moving right");


        //forwardDestination = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);

        //transform.position = Vector3.Lerp(currentPos, forwardDestination, fracJourney);
    }




    public void Pause()
    {
        float waitTimer = 10;

        waitTimer -= Time.deltaTime;
        if(waitTimer <= 0)
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Land"))
        {
            playerState = StatePlayer.dead;
        }
    }

}
