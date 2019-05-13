using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public const int  MINE_FLAG_MAX = 20;
    public int mineFlagCount;

    const int SAFE_FLAG_MAX = 20;
    int safeFlagCount;



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
        if (safeFlagCount < SAFE_FLAG_MAX)
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
                        hit.transform.GetComponent<Cell>().MarkSafe();
                        safeFlagCount++;
                    }
                }
            }
        }

        if (mineFlagCount < SAFE_FLAG_MAX)
        {

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
                        mineFlagCount++;
                    }
                }
            }
        }
    }



}
