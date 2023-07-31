using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SCcoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;


    private void Awake()
    {
        if (scoreText != null)
        {
            scoreText.text = ScoreManager.instance.Score.ToString();
        }
        if (highscoreText != null)
        {
            highscoreText.text = ScoreManager.instance.HighScore.ToString();
        }
    }

    private void Update()
    {

        if (scoreText != null)
        {
            scoreText.text = ScoreManager.instance.Score.ToString();
        }
        if (highscoreText != null)
        {
            highscoreText.text = ScoreManager.instance.HighScore.ToString();
        }

    }
}
