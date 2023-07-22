using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{


    [SerializeField] private float lifes;
    public static PlayerHealth instance;
    private float healthonAwake;


    // --------------------------------------------------------------------------------------
    // Core  functions
    // --------------------------------------------------------------------------------------


    private void Awake()
    {
        healthonAwake = lifes;
        instance = this;
        EventManager.instance.onDamageRecieved += HandleDamageRecieved;
        EventManager.instance.onNewGameSelected += HandleNewGameSelected;
    }
    private void Update()
    {
        if (lifes == 0)
        {
            EventManager.instance.HandleDefeat();
        }
    }
    private void OnDestroy()
    {
        EventManager.instance.onDamageRecieved -= HandleDamageRecieved;
        EventManager.instance.onNewGameSelected -= HandleNewGameSelected;
    }



    // --------------------------------------------------------------------------------------
    // Event-dependant  functions
    // --------------------------------------------------------------------------------------

    private void HandleNewGameSelected()
    {
        lifes = healthonAwake;
    }

    private void HandleDamageRecieved(float damage)
    {
        lifes -= damage;
        EventManager.instance.HandleDamageRecievedUI();
    }


    // --------------------------------------------------------------------------------------
    //Player Health-speciefic  functions
    // --------------------------------------------------------------------------------------

    public float GetHealthValue()
    {
        return lifes;
    }



}
