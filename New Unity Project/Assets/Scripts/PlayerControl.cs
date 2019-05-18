using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerControl : MonoBehaviour
{

    public float hitPoints;
    public float moveSpeed;


    Vector3 currentPos;
    Vector3 forwardDestination;
    private float distance;
    bool isMoving = false;
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
    

    public virtual void Start()
    {
        gameBoard = FindObjectOfType<GameBoard>();
        currentPos = this.transform.position;
        isMoving = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        HealthCheck();

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


    public virtual void SetStartingPosition(int startingRow, int startingCol)
    {
        this.transform.position = new Vector3(transform.position.x + startingRow, transform.position.y, transform.position.z + startingCol);
        
    }


    public virtual void QueueCommand(int direction)
    {
        commandQueue.Add(direction);
    }

    public virtual void QueueLeftCommand()
    {
        commandQueue.Add(2);
    }

    public virtual void QueueRightCommand()
    {
        commandQueue.Add(3);
    }

    public virtual void ExecuteCommands()
    {
        int count = 1;
        foreach (int command in commandQueue)
        {
            Debug.Log(command);
            if (command == 1)
            {
                Invoke("MoveForward", 1f + count);
                
            }
            if (command == 2)
            {
                Invoke("MoveLeft", 1f + count);
            }
            if (command == 3)
            {
                Invoke("MoveRight", 1f + count);
            }
            count++;
        }

        commandQueue.Clear();

    }



    //these are the button seletion methods

    public virtual void ToggleForward()
    {

        forwardDestination = new Vector3(transform.position.x, transform.position.y, transform.position.z + step);
        forward = true;
    }
    public virtual void ToggleLeft()
    {

        forwardDestination = new Vector3(transform.position.x - step, transform.position.y, transform.position.z);
        left = true;
    }
    public virtual void ToggleRight()
    {
        forwardDestination = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);
        right = true;
    }
    //these are the command methods
    public virtual void MoveForward()
    {
        //this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + step);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + step); ;        

    }
    public virtual void MoveLeft()
    {
        //this.transform.position = new Vector3(transform.position.x-step, transform.position.y, transform.position.z);

        transform.position = new Vector3(transform.position.x - step, transform.position.y, transform.position.z); 
    }

    public virtual void MoveRight()
    {

        transform.position = new Vector3(transform.position.x + step, transform.position.y, transform.position.z); ;
    }

    public virtual void Pause()
    {
        float waitTimer = 10;

        waitTimer -= Time.deltaTime;
        if(waitTimer <= 0)
        {
            return;
        }
    }

    public virtual void TakeDamage(int damageIn)
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
