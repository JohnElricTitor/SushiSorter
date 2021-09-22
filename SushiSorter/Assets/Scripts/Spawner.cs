using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Items item;

    [SerializeField] int timer;
    int randPos;
    int randType;

    private void Start()
    {
        InvokeRepeating("Spawn", 0, timer);
    }
    
    
    void Spawn()
    {
        randPos = Random.Range(0, spawnPoints.Length);
        randType = Random.Range(0, 4);

        if(randType == 0)
            Instantiate(item.Maki[Random.Range(0, item.Maki.Length)], spawnPoints[randPos].position, Quaternion.identity);
        if (randType == 1)
            Instantiate(item.Nigiri[Random.Range(0, item.Nigiri.Length)], spawnPoints[randPos].position, Quaternion.identity);
        if (randType == 2)
            Instantiate(item.Ikura[Random.Range(0, item.Ikura.Length)], spawnPoints[randPos].position, Quaternion.identity);
        if (randType == 3)
            Instantiate(item.Roll[Random.Range(0, item.Roll.Length)], spawnPoints[randPos].position, Quaternion.identity);

    }
}
