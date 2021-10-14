using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;                     //all spawn point positions for containers
    public GameObject container;                        //container 

    private void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Spawn(i);
        }
    }
    public void Spawn (int spawnPos)
    {
        GameObject con = Instantiate(container, spawnPoints[spawnPos].position, Quaternion.identity, spawnPoints[spawnPos]);
        con.GetComponent<Containers>().spawnPos = spawnPos;
    }
}
