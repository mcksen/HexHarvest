using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{


    private float lifes;
    public static PlayerHealth instance;


    void Awake()
    {
        lifes = 3;
        instance = this;
        EventManager.onDamageRecieved += HandleDamageRecieved;

    }

    public void HandleDamageRecieved(float damage)
    {
        lifes -= damage;

    }


    public void OnDestroy()
    {
        EventManager.onDamageRecieved -= HandleDamageRecieved;
    }

    public float GetHealthValue()
    {
        return lifes;
    }


    public void Update()
    {
        if (lifes == 0)
        {
            EventManager.HandleDefeat();

        }
    }

}
