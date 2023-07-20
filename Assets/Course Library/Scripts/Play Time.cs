
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;
using System.Diagnostics;

public class PlayTime : MonoBehaviour
{

    private Stopwatch sessionTime = new Stopwatch();
    private TimeSpan currentTime = new TimeSpan();
    public static PlayTime instance;

    private void Awake()
    {
        instance = this;
        StartTimer();
    }



    public void StartTimer()
    {
        sessionTime.Start();
    }

    public void StopTimer()
    {
        sessionTime.Stop();
    }

    public double GetCurrentTime()
    {
        currentTime = sessionTime.Elapsed;
        return currentTime.TotalSeconds;
    }
    public void RestartTime()
    {
        sessionTime.Restart();

    }
}
