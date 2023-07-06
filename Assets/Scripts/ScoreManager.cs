using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public void Awake()
    {
        //Change to load from the saved file when savemanager is made
        score = 0;
        EventManager.onScoreIncreased += IncreaseScore;
    }

    public void IncreaseScore()
    {
        score += 1;
    }



    public void OnDestroy()
    {
        EventManager.onScoreIncreased -= IncreaseScore;
    }
}
