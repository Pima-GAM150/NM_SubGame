using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cell : MonoBehaviour
{

    public int cellType;
    //cell types are 
    //1 == water 2== shadow 3==  4 = 5= 6= 7= 8=  9= Land

    public Cell ()
    {
       
    }

    public void SetNewLocation(int startingRow, int startingCol)
    {
        this.transform.position = new Vector3(transform.position.x + startingRow, transform.position.y, transform.position.z + startingCol);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
