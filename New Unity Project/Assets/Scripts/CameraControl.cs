using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ClickOnCell();
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
                if (hit.transform.GetComponent<Cell>() != null)
                {
                    hit.transform.GetComponent<Cell>().isMarkedSafe = true;
                }
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



}
