using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float hitPoints;
    public float moveSpeed;

    public GameObject playerPiece;

    public Vector3 currentPos;
    public Vector3 forwardDestination;
    public float distance;
    public bool isMoving = false;
    bool buttonsActive;

    bool forward = false;
    bool left = false;
    bool right = false;

    float startTime;

    //so player will click buttons to fill the cammand list, the int will dictate the movement type.
    public List<Transform> commandQueue = new List<Transform>();

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
        ClickOnCell();
        HealthCheck();
        if (!isMoving)
        {
            buttonsActive = true;
        }
        if (isMoving)
        {
            MoveShip();
        }


    }

    public void ClickOnCell()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit " + hit.transform);
                commandQueue.Add(hit.transform);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                
                Debug.Log("Hit " + hit.transform);
                if (hit.transform.GetComponent<Shadows>() != null)
                {
                    hit.transform.GetComponent<Shadows>().MarkForMines();
                }
            }
        }
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
            playerPiece.transform.position = commandQueue[command].position;
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

    public void MoveUp()
    {

    }
    public void MoveLeft()
    {
     //   if (buttonsActive)
          //  commandQueue.Add(2);
    }

    public void MoveRight()
    {
        //if (buttonsActive)
            //commandQueue.Add(3);
    }


    public void SetSail()
    {
        isMoving = !isMoving;
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
