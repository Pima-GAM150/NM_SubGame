using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : Cell
{
    bool gameEnded;
    bool win = false;
    bool fail = false;
   public bool markedForMines = false;
   public bool isMineSpot = false;

    // Start is called before the first frame update
    void Start()
    {
        cellType = 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameEnded)
        {
            if (markedForMines)
            GetComponent<Renderer>().material.color = Color.red;
        }

        if (gameEnded)
        {
            if (isMineSpot && !markedForMines)
            {
                GetComponent<Renderer>().material.color = Color.black;
                fail = true;
            }
            else if (!isMineSpot && markedForMines)
            {
                GetComponent<Renderer>().material.color = Color.white;
                fail = true;

            }
            else if (isMineSpot && markedForMines)
            {
                GetComponent<Renderer>().material.color = Color.green;
                win = true;
            }
        }

    }

    public void MarkForMines()
    {

        markedForMines = !markedForMines;

    }

    public void Detonate()
    {

        gameEnded = !gameEnded;

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerControl target = other.GetComponent<PlayerControl>();

            target.TakeDamage(2);
        }

        if (other.CompareTag("Water"))
        {
            transform.position = other.transform.position;
            other.transform.position = transform.position;

        }
    }
}
