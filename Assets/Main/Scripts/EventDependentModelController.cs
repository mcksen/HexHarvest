using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDependentModelController : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private UnityEvent gameActive;
    [SerializeField] private UnityEvent gameInActive;
    private void Awake()
    {

        EventManager.instance.onNewGameSelected += HandleNewGameSelected;
        EventManager.instance.onMenuSelected += HandleMenuSelected;
        EventManager.instance.onPauseSelected += HandlePauseSelected;
        EventManager.instance.onResumeSelected += HandleResumeSelected;
        EventManager.instance.onDefeated += HandleDefeat;
    }
    private void OnDestroy()
    {

        EventManager.instance.onNewGameSelected -= HandleNewGameSelected;
        EventManager.instance.onMenuSelected -= HandleMenuSelected;
        EventManager.instance.onPauseSelected -= HandlePauseSelected;
        EventManager.instance.onResumeSelected -= HandleResumeSelected;
        EventManager.instance.onDefeated -= HandleDefeat;
    }






    private void HandleNewGameSelected()
    {
        if (model != null)
        {
            SetModelActive();
        }
    }
    private void HandleDefeat()
    {
        if (model != null)
        {
            SetModelINactive();
        }
    }

    private void HandleResumeSelected()
    {
        if (model != null)
        {
            SetModelActive();
        }
    }

    private void HandlePauseSelected()
    {
        if (model != null)
        {
            SetModelINactive();
        }
    }

    private void HandleMenuSelected()
    {
        if (model != null)
        {
            SetModelINactive();
        }
    }



    private void SetModelActive()
    {

        gameActive.Invoke();
    }

    private void SetModelINactive()
    {

        gameInActive.Invoke();
    }
}
