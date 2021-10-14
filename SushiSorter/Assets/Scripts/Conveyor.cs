using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    BoxCollider boxCollider;                        //Used to get the width of the conveyor belt for spawn and deSpawn
    float width;                                    //width of conveyor
    [HideInInspector] public float speed;           //Speed of conveyor belt
    [SerializeField] Stats stats;

    private void Start()
    {
        speed = stats.ConveyorSpeed;
        boxCollider = GetComponent<BoxCollider>();
        width = boxCollider.size.x;
    }
    private void Update()
    {
        if (transform.position.x > -width)                          //if position is more than width max, move to left
            transform.Translate(speed * Time.deltaTime, 0, 0);
        else if (transform.position.x <= -width)                    //if less than width max, move to original plus width offset to attached to other conveyor end piece 
            transform.position = new Vector3(width, transform.parent.position.y, transform.parent.position.z);
    }
}
