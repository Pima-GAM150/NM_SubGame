using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : Cell
{
    public int shipsSaved = 0;


    public delegate void SaveShip(Port SaveAShip);
    public static event SaveShip PlayerSavedAShipEvent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSavedAShipEvent(this);
            shipsSaved++;
        }

    }
}
