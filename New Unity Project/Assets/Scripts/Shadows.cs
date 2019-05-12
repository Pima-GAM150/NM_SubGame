using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : Cell
{



    // Start is called before the first frame update
    void Start()
    {
        cellType = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerControl target = other.GetComponent<PlayerControl>();

            target.TakeDamage(2);
        }
    }
}
