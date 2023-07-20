using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProgression : MonoBehaviour
{

    [SerializeField] private int maxSpawnQuantity;
    [SerializeField] private int minSpawnQuantity;
    [SerializeField] private int timespan;
    [SerializeField] private SpawnRandomObjects spawn;
    private double time;

    private void Start()
    {
        time = PlayTime.instance.GetCurrentTime();

    }


    public void SpawnObjects()
    {
        int count = GetObjectCount();
        spawn.SpawnObjects(count);
    }




    public int GetObjectCount()
    {

        double spanwCount = time / timespan;
        spanwCount = Mathf.Clamp((float)spanwCount, minSpawnQuantity, maxSpawnQuantity);

        return Mathf.RoundToInt(Convert.ToInt32(spanwCount));

    }
}
