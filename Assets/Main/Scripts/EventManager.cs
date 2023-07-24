using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "EventManager", menuName = "Scriptable Objects/EventManager")]
public class EventManager : ScriptableObject

{
    public static EventManager instance;
    public delegate void CollectionEvents(GameObject village);
    public CollectionEvents onInfantCollect;
    public delegate void ScoreEvent();
    public ScoreEvent onScoreIncreased;

    public delegate void PlayerHit(float damage);
    public PlayerHit onDamageRecieved;

    public delegate void UIevents();
    public UIevents onDamageRecievedUI;

    public delegate void GameStateEvent();

    public GameStateEvent onOpenGame;
    public GameStateEvent onDefeated;
    public GameStateEvent onNewGameSelected;
    public GameStateEvent onPauseSelected;
    public GameStateEvent onResumeSelected;
    public GameStateEvent onMenuSelected;
    public GameStateEvent onExitSelected;

    public delegate void TimeEvent();
    public TimeEvent onTimeStart;

    public delegate void AudioEvent();
    public AudioEvent PlayGameAwake;

    public void Initialise()
    {
        instance = this;
    }

    public void TryCollectInfant(GameObject village)
    {
        if (onInfantCollect != null)
        {
            onInfantCollect(village);
        }
    }

    public void HandleDamageRecieved(float damage)
    {
        if (onDamageRecieved != null)
        {
            onDamageRecieved(damage);
        }
    }
    public void HandleDamageRecievedUI()
    {
        if (onDamageRecievedUI != null)
        {
            onDamageRecievedUI();
        }
    }

    public void HandleTimeStart()
    {
        if (onTimeStart != null)
        {
            onTimeStart();
        }
    }

    // --------------------------------------------------------------------------------------
    // GameState Events
    // --------------------------------------------------------------------------------------
    public void HandleNewGameSelected()
    {
        if (onNewGameSelected != null)
        {
            onNewGameSelected();
        }
    }
    public void HandleDefeat()
    {
        if (onDefeated != null)
        {
            onDefeated();
        }
    }
    public void HandlePauseSelected()
    {
        if (onPauseSelected != null)
        {
            onPauseSelected();
        }
    }
    public void HandleResumeSelected()
    {
        if (onResumeSelected != null)
        {
            onResumeSelected();
        }
    }
    public void HandleMenuSelected()
    {
        if (onMenuSelected != null)
        {
            onMenuSelected();
        }
    }
    public void HandleExitSelected()
    {
        if (onExitSelected != null)
        {
            onExitSelected();
        }
    }
    public void HandleOpenGame()
    {
        if (onOpenGame != null)
        {
            onOpenGame();

        }
    }
    public void HandlePlayGameAwake()
    {
        if (PlayGameAwake != null)
        {
            PlayGameAwake();
        }
    }
}
