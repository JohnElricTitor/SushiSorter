using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    BoxCollider boxCollider;
    Rigidbody rb;
    float width;
    public float speed;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        width = boxCollider.size.x;
    }
    private void Update()
    {
        if (transform.position.x > -width)
            transform.Translate(speed * Time.deltaTime, 0, 0);
        else if (transform.position.x <= -width)
            transform.position = new Vector3(width, -0.1f, 0);
    }
}
