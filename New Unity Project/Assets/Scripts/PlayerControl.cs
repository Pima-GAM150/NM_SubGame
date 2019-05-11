using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float hitPoints;
    public float moveSpeed;

    public Vector3 currentPos;
    public Vector3 forwardDestination;
    public Transform rightDestination;
    public Transform leftDestination;
    public float distance;
    public bool isMoving = false;
    bool buttonsActive;

    bool forward = false;
    bool left = false;
    bool right = false;

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
        HealthCheck();
        if (!isMoving)
        {
            buttonsActive = true;
        }
        if (isMoving)
        {
            MoveShip();
        }


        if (forward)
            MoveForward();
        if (left)
            MoveLeft();
        if (right)
            MoveRight();


    }

    private void HealthCheck()
    {
        if (hitPoints <= 0)
        {
            playerState = StatePlayer.dead;

            Destroy(gameObject);
        }
        else
        {
            playerState = StatePlayer.alive;
        }
    }

    private void MoveShip()
    {
        for (int command = 0; command< commandQueue.Count; command++)
        {
            Debug.Log("CurrentCommand" + command);
            //float waitTimer = 10;
            //while (waitTimer > 0)
            //{
            //    waitTimer -= Time.deltaTime;
            //    Debug.Log(waitTimer);
            //}
            //currentPos = this.transform.position;
            if (commandQueue[command] == 1)
            {
                forwardDestination = new Vector3(transform.position.x, transform.position.y, transform.position.z + step);
                forward = true;
            }
            if (commandQueue[command] == 2)
            {
                forwardDestination = new Vector3(transform.position.x - step, transform.position.y, transform.position.z);
                left = true;
            }
            if (commandQueue[command] == 3)
            {
                forwardDestination = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);
                right = true;
            }
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
        

        if (Vector3.Distance(currentPos, forwardDestination) < .5)
        {
            forward = false;

           
        }
        else transform.position = Vector3.MoveTowards(transform.position, forwardDestination, moveSpeed * Time.deltaTime);
    }
    public void MoveLeft()
    {
        //this.transform.position = new Vector3(transform.position.x-step, transform.position.y, transform.position.z);

        if (Vector3.Distance(currentPos, forwardDestination) < .5)
        {
            left = false;


        }
        else transform.position = Vector3.MoveTowards(transform.position, forwardDestination, moveSpeed * Time.deltaTime);
    }

    public void MoveRight()
    {
        if (Vector3.Distance(currentPos, forwardDestination) < .5)
        {
            right = false;


        }
        else transform.position = Vector3.MoveTowards(transform.position, forwardDestination, moveSpeed * Time.deltaTime);
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

    public void TakeDamage(int damageIn)
    {
        hitPoints -= damageIn;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Land"))
        {
            playerState = StatePlayer.dead;
        }
    }

}
