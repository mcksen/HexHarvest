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





    public static void TryCollectyInfant(GameObject village)
    {
        if (onInfantCollect != null)
        {
            onInfantCollect(village);
        }
    }


}
