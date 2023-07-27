using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle = null;



    private void Awake()
    {
        EventManager.instance.onDamageRecieved += HandleDamageRecieved;
    }


    private void OnDestroy()
    {
        EventManager.instance.onDamageRecieved -= HandleDamageRecieved;
    }
    private void HandleDamageRecieved(float damage)
    {

        particle.Play();

    }
}
