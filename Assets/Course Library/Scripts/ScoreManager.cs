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
        //Change to load from the saved file when savemanager is made
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
        if (highscoreText != null)
        {
            highscoreText.text = highScore.ToString();
        }
        EventManager.onScoreIncreased += IncreaseScore;
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



    public void OnDestroy()
    {
        EventManager.onScoreIncreased -= IncreaseScore;
    }
}
