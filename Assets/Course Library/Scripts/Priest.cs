using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : MonoBehaviour
{

    [SerializeField] private SpawnRandomObjects bulletSpawn;
    [SerializeField] private int numberToSpawn;


    private void Awake()
    {
        bulletSpawn.SpawnObjects(numberToSpawn);
    }










}
