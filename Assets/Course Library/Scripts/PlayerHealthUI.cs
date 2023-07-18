using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{

    [SerializeField] private int numberOfHearts;
    [SerializeField] private Image[] hearts;
    private float remainingHealth;

    public void Awake()
    {

        EventManager.onDamageRecievedUI += HandleDamageRecievedUI;
    }


    public void Update()
    {

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            remainingHealth = PlayerHealth.instance.GetHealthValue();
        }

    }

    public void HandleDamageRecievedUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].fillAmount = remainingHealth - i;
        }

    }


    public void OnDestroy()
    {
        EventManager.onDamageRecievedUI -= HandleDamageRecievedUI;
    }

}
