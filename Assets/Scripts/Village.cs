using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private Transform model;
    [SerializeField] private bool doesHaveChild;
    [SerializeField] private GameObject colliderEmptyObject;


    public void Awake()
    {
        doesHaveChild = true;

        EventManager.onInfantCollect += TryCollectyInfant;
    }

    public void OnDestroy()
    {
        EventManager.onInfantCollect -= TryCollectyInfant;
    }

    public void TryCollectyInfant(GameObject village)
    {
        if (village == colliderEmptyObject && doesHaveChild == true)
        {
            doesHaveChild = false;
            EventManager.onScoreIncreased();

        }
    }


}
