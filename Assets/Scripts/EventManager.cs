using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public delegate void CollectionEvents(GameObject village);

    public static CollectionEvents onInfantCollect;
    public delegate void ScoreEvent();
    public static ScoreEvent onScoreIncreased;

    public delegate void PlayerHit(float damage);
    public static PlayerHit onDamageRecieved;


    public delegate void GameOver();
    public static GameOver onDefeated;



    public static void TryCollectyInfant(GameObject village)
    {
        if (onInfantCollect != null)
        {
            onInfantCollect(village);
        }
    }

    public static void HandleDamageRecieved(float damage)
    {
        if (onDamageRecieved != null)
        {
            onDamageRecieved(damage);
        }
    }
    public static void HandleDefeat()
    {
        if (onDefeated != null)
        {
            onDefeated();
        }
    }




}
