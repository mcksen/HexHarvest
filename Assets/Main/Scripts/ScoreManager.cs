using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[CreateAssetMenu(fileName = "ScoreManager", menuName = "Scriptable Objects/ScoreManager")]

public class ScoreManager : ScriptableObject
{

    public static ScoreManager instance;



    private int score;
    public int Score => score;
    private int highScore;
    public int HighScore => highScore;
    public void Instantiate()
    {
        instance = this;
        score = 0;

        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore = PlayerPrefs.GetInt("Highscore");
        }
        else
        {
            highScore = 0;
        }


        EventManager.instance.onScoreIncreased += IncreaseScore;
        EventManager.instance.onNewGameSelected += HandleNewGameSelected;
    }




    // --------------------------------------------------------------------------------------
    // Event-dependant  functions
    // --------------------------------------------------------------------------------------

    private void HandleNewGameSelected()
    {
        score = 0;
    }

    public void IncreaseScore()
    {
        score += 1;

        if (score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt("Highscore", highScore);
            PlayerPrefs.Save();
        }
    }
    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }
}
