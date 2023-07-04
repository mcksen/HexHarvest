using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomObjects : MonoBehaviour
{
    [SerializeField] private GameObject objecttoSpawn;
    [SerializeField] private float xRange;
    [SerializeField] private float zRange;
     [SerializeField] private Vector3 position;

     [SerializeField] private int maxSpawnQuantity;

     [SerializeField] private int minSpawnQuantity;

     [SerializeField] private int timespan;
    private List<GameObject> listToSpawn  = new List<GameObject>();


    
   
    public int GetObjectCount(int maxQuantity, int minQuantity, int timespan)
        {
             float time = Time.realtimeSinceStartup;
             float spanwCount = time / timespan;
             spanwCount =  Mathf.Clamp(spanwCount, minQuantity, maxQuantity);

        return Mathf.RoundToInt(spanwCount);
        }


    private void Rebuild()
    {
       
        if (listToSpawn.Count != 0)
        {
            for (int i = listToSpawn.Count-1; i >= 0; i--)
            {
                Destroy(listToSpawn[i]);
            }
        }
    }

    public void SpawnObjects()
        {

        Rebuild();
        int count = GetObjectCount(maxSpawnQuantity,minSpawnQuantity, timespan);
                
           
            for (int i=0; i< count; i++)
            {
                GameObject spawn = GameObject.Instantiate(objecttoSpawn, transform.position, transform.rotation, transform);
                spawn.transform.position = new Vector3(Random.Range(transform.position.x, transform.position.x+ xRange), transform.position.y, Random.Range(transform.position.z, transform.position.z+ zRange));
                listToSpawn.Add(spawn);

            }
            
        }
}
