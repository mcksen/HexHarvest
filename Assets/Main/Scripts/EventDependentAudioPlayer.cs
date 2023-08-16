using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDependentAudioPlayer : MonoBehaviour
{
    [SerializeField] private string gameOnAudio;
    [SerializeField] private string menuTheme;
    [SerializeField] private string ripTheme;
    [SerializeField] private string hit;
    [SerializeField] private string witchDeath;
    [SerializeField] private string babyCry;
    [SerializeField] private string buttonClick;
    public void Awake()
    {

        EventManager.instance.onButtonClickSound += HandleButtonClickSound;
        EventManager.instance.onScoreIncreased += HandleScoreIncreased;
        EventManager.instance.PlayGameAwake += HandlePlayGameAwake;
        EventManager.instance.onNewGameSelected += HandleNewGameSelected;
        EventManager.instance.onMenuSelected += HandleMenuSelected;
        EventManager.instance.onPauseSelected += HandlePauseSelected;
        EventManager.instance.onResumeSelected += HandleResumeSelected;
        EventManager.instance.onDefeated += HandleDefeat;
        EventManager.instance.onDamageRecieved += HandleDamageRecieved;
    }


    private void OnDestroy()
    {
        EventManager.instance.onButtonClickSound -= HandleButtonClickSound;
        EventManager.instance.onScoreIncreased -= HandleScoreIncreased;
        EventManager.instance.PlayGameAwake -= HandlePlayGameAwake;
        EventManager.instance.onNewGameSelected -= HandleNewGameSelected;
        EventManager.instance.onMenuSelected -= HandleMenuSelected;
        EventManager.instance.onPauseSelected -= HandlePauseSelected;
        EventManager.instance.onResumeSelected -= HandleResumeSelected;
        EventManager.instance.onDefeated -= HandleDefeat;
        EventManager.instance.onDamageRecieved -= HandleDamageRecieved;
    }

    // --------------------------------------------------------------------------------------
    // Event-dependent functions
    // --------------------------------------------------------------------------------------
    private void HandleButtonClickSound()
    {
        Play(buttonClick);
    }

    private void HandleScoreIncreased()
    {
        Play(babyCry);
    }
    private void HandleDamageRecieved(float damage)
    {
        Play(hit);
    }
    private void HandlePlayGameAwake()
    {

        Play(menuTheme);
    }


    private void HandleNewGameSelected()
    {
        StopAllAudio();
        Play(gameOnAudio);
    }
    private void HandleDefeat()
    {
        StopAllAudio();
        Play(witchDeath);
        PlayDelayed(ripTheme);
    }

    private void HandleResumeSelected()
    {
        StopAllAudio();
        UnPause(gameOnAudio);
    }

    private void HandlePauseSelected()
    {
        Pause(gameOnAudio);
        Play(menuTheme);
    }

    private void HandleMenuSelected()
    {

        StopAllAudio();
        Play(menuTheme);
    }

    // --------------------------------------------------------------------------------------
    //Class functions
    // --------------------------------------------------------------------------------------
    public void StopAllAudio()
    {
        AudioManager.instance.StopAllAudio();
    }

    public void Play(string name)
    {
        AudioManager.instance.Play(name);
    }
    public void Pause(string name)
    {
        AudioManager.instance.Pause(name);
    }
    public void UnPause(string name)
    {
        AudioManager.instance.UnPause(name);
    }

    public void PlayDelayed(string name)
    {
        AudioManager.instance.PlayDelayed(name);
    }
}
