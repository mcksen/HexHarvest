using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] GameObject heartContainer;
    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;
    List<Image> im = new List<Image>();
    float fillAmount;
    public void Awake()
    {
        im.Add(heart1.GetComponent<Image>());
        im.Add(heart2.GetComponent<Image>());
        im.Add(heart3.GetComponent<Image>());
        fillAmount = im[0].fillAmount;
        EventManager.onDamageRecieved += HandleDamageRecieved;
    }


    public void Update()
    {

        healthText.text = "HEALTH:" + PlayerHealth.instance.GetHealthValue();
        if (im[0].fillAmount == 0)
        {
            fillAmount = im[1].fillAmount;
        }
        if (im[1].fillAmount == 0)
        {
            fillAmount = im[2].fillAmount;
        }
    }

    public void HandleDamageRecieved(float damage)
    {
        fillAmount -= damage;

    }


}
