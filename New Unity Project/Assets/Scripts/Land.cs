using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : Cell
{
    // Start is called before the first frame update
    void Start()
    {
        cellType = 9;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl target = other.GetComponent<PlayerControl>();

            target.TakeDamage(10);
        }
    }
}
