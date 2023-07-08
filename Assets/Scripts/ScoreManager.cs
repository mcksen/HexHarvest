using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;




    private int score = 0;
    private int highScore = 0;




    public void Start()
    {
        //Change to load from the saved file when savemanager is made

        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "Highscore: " + highScore.ToString();

        EventManager.onScoreIncreased += IncreaseScore;
    }

    public void IncreaseScore()
    {
        score += 1;
        scoreText.text = "SCORE: " + score.ToString();
        if (score > highScore)
        {
            highScore = score;
            highscoreText.text = "Highdcore: " + highScore.ToString();
        }
    }



    public void OnDestroy()
    {
        EventManager.onScoreIncreased -= IncreaseScore;
    }
}
