using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "GameManager")]
public class Stats : ScriptableObject
{
    public int servings;
    public int bonusScore;
    public int complaints;
    public int totalScore;

    public int death;
    public float SpawnRate;
    public float ConveyorSpeed;
 

    public bool isEnd;                     //think about it 
    public bool isPause;

 public void Pause()
    {
        Time.timeScale = 0;
        isPause = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        isPause = false;
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }


    public void Reset()
    {
        servings = 0;
        bonusScore = 0;
        complaints = 0;
        totalScore = 0;
        death = 0;
        SpawnRate = 0;
        ConveyorSpeed = 0;

        isEnd = false;                  
        isPause = false;
    }
}
