using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;




    private int score;
    private int highScore;
    public void Awake()
    {
        score = 0;

        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore = PlayerPrefs.GetInt("Highscore");
        }
        else
        {
            highScore = 0;
        }

    }




    public void Start()
    {

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
        if (highscoreText != null)
        {
            highscoreText.text = highScore.ToString();
        }
        EventManager.instance.onScoreIncreased += IncreaseScore;
        EventManager.instance.onNewGameSelected += HandleNewGameSelected;
    }

    public void OnDestroy()
    {
        EventManager.instance.onScoreIncreased -= IncreaseScore;
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
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt("Highscore", highScore);
            PlayerPrefs.Save();
        }
    }



}
