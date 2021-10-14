using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] Stats stats;
    [SerializeField] GameObject scoreBoard;
    [SerializeField] TMP_Text servings;
    [SerializeField] TMP_Text bonus;
    [SerializeField] TMP_Text complaints;
    [SerializeField] TMP_Text total;
    [SerializeField] TMP_Text HiSscore;
    private void Start()
    {
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/Saves/saveName.save");
        HiSscore.text = SaveData.current.HighScore.ToString();
    }

    private void Update()
    {
        if(stats.complaints >= stats.death)
        {
            scoreBoard.SetActive(true);
            servings.text = stats.servings.ToString();
            bonus.text = stats.bonusScore.ToString();
            complaints.text = stats.complaints.ToString();
            stats.totalScore = (stats.servings + stats.bonusScore) - stats.complaints; 
            total.text = stats.totalScore.ToString();
            Time.timeScale = 0;
            stats.isEnd = true;  //not sure what this is being used for 
            
            if(stats.totalScore > SaveData.current.HighScore)
            {

                SaveData.current.HighScore = stats.totalScore;
                SerializationManager.Save("saveName", SaveData.current);
            }
        }
    }   
}
    
