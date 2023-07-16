using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : MonoBehaviour
{

    [SerializeField] private SpawnRandomObjects bulletSpawn;



    // Start is called before the first frame update
    void Awake()
    {
        Rebuild();
    }




    public void Rebuild()
    {
        bulletSpawn.SpawnObjects();

    }





}
