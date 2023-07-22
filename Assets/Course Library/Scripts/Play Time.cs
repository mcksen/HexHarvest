
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
        EventManager.instance.onNewGameSelected += HandleNewGameSelected;
        EventManager.instance.onMenuSelected += HandleMenuSelected;
        EventManager.instance.onPauseSelected += HandlePauseSelected;
        EventManager.instance.onResumeSelected += HandleResumeSelected;
        EventManager.instance.onDefeated += HandleDefeat;
    }
    private void onDestroy()
    {

        EventManager.instance.onNewGameSelected -= HandleNewGameSelected;
        EventManager.instance.onMenuSelected -= HandleMenuSelected;
        EventManager.instance.onPauseSelected -= HandlePauseSelected;
        EventManager.instance.onResumeSelected -= HandleResumeSelected;
        EventManager.instance.onDefeated -= HandleDefeat;
    }


    // --------------------------------------------------------------------------------------
    // Event-dependant functions
    // --------------------------------------------------------------------------------------

    private void HandleNewGameSelected()
    {
        RestartTime();
        EventManager.instance.onTimeStart();
    }
    private void HandleDefeat()
    {
        StopTimer();
    }
    private void HandlePauseSelected()
    {
        StopTimer();
    }
    private void HandleResumeSelected()
    {
        StartTimer();
    }
    private void HandleMenuSelected()
    {
        StopTimer();
    }



    // --------------------------------------------------------------------------------------
    // Time-speciefic functions
    // --------------------------------------------------------------------------------------
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
