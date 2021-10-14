using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : SushiType
{
    
    float speed;
    [SerializeField] float rayLength;

    
    private void Update()
    {
        FloorCheck();
    }

    void FloorCheck()
    {
        RaycastHit hit;                                                              //STORE WHAT THE RAYCASTS HITS 
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);      //DRAWS THE RAYCAST FROM POINT TOUCHED ON SCREEN

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider.tag == "Conveyor")
            {
                speed = hit.transform.GetComponent<Conveyor>().speed;
                Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.green);      //DRAWS THE RAYCAST FROM POINT TOUCHED ON SCREEN
            }
        }
        else
            speed = 0;

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
