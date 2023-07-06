using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private Transform model;
    private bool doesHaveChild;


    public void Awake()
    {
        doesHaveChild = true;
    }

    


}
