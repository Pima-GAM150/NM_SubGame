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

    public override void Update()
    {
        base.Update();

        if (!gameEnded)
        {
            if (markedForMines)
            GetComponent<Renderer>().material.color = Color.red;
        }

        if (gameEnded)
        {
            if (isMineSpot && !markedForMines)
            {
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

        markedForMines = true;

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
            if (isMineSpot && !isMarkedSafe)
            {
                target.TakeDamage(10);

                GetComponent<Renderer>().material.color = Color.black;
            }
            else if(!isMarkedSafe)
            {
                int dice = Random.Range(1, 6);
                if (dice < 5)
                    target.TakeDamage(1);
            }
            else if (isMarkedSafe)
            {
            }
        }
        
    }
}
