
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        EventManager.instance.onExitSelected += HandleExitSelected;
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
    private void HandleDefeat()
    {
        SetTimeScaleINactive();
    }

    private void HandleNewGameSelected()
    {
        SetTimeScaleActive();
    }

    private void HandleResumeSelected()
    {
        SetTimeScaleActive();
    }

    private void HandlePauseSelected()
    {
        SetTimeScaleINactive();
    }

    private void HandleMenuSelected()
    {
        SetTimeScaleINactive();
    }

    private void HandleExitSelected()
    {
        ExitGame();
    }

    // --------------------------------------------------------------------------------------
    // Game Manager-speciefic  functions
    // --------------------------------------------------------------------------------------

    private void ExitGame()
    {
        Application.Unload();
        Application.Quit();
    }


    private void SetTimeScaleActive()
    {
        Time.timeScale = 1;
    }

    private void SetTimeScaleINactive()
    {
        Time.timeScale = 0;
    }
}