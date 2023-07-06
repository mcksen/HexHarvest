
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnRandomObjects : MonoBehaviour
{
    [SerializeField] private GameObject objecttoSpawn;
    [SerializeField] private float xRange;
    [SerializeField] private float zRange;
    [SerializeField] private Vector3 position;

    [SerializeField] private int maxSpawnQuantity;

    [SerializeField] private int minSpawnQuantity;
    [SerializeField] private float gap;

    [SerializeField] private int timespan;
    [SerializeField] private UnityEvent evvy;
    private List<GameObject> listToSpawn = new List<GameObject>();




    public int GetObjectCount(int maxQuantity, int minQuantity, int timespan)
    {
        float time = Time.realtimeSinceStartup;
        float spanwCount = time / timespan;
        spanwCount = Mathf.Clamp(spanwCount, minQuantity, maxQuantity);

        return Mathf.RoundToInt(spanwCount);
    }


    private void Rebuild()
    {

        if (listToSpawn.Count != 0)
        {
            for (int i = listToSpawn.Count - 1; i >= 0; i--)
            {
                Destroy(listToSpawn[i]);

            }
        }
        listToSpawn.Clear();
    }

    public Vector3 GetPosition()
    {
        Vector3 position = new Vector3();
        List<bool> isOverlap = new List<bool>();
        bool isAssigned = false;
        // t = number of tries
        int t = 0;
        while (!isAssigned && t < 100)
        {
            Vector3 tryPosition = new Vector3(Random.Range(transform.position.x, transform.position.x + xRange), transform.position.y, Random.Range(transform.position.z, transform.position.z + zRange));
            if (listToSpawn.Count > 0)
            {
                for (int i = 0; i < listToSpawn.Count; i++)
                {
                    float difference = Vector3.Distance(tryPosition, listToSpawn[i].transform.position);


                    if (difference < gap)
                    {
                        isOverlap.Add(true);
                    }
                }
                if (isOverlap.Count == 0)
                {
                    position = tryPosition;
                    isAssigned = true;
                }
            }

            else
            {
                position = tryPosition;
                isAssigned = true;
            }
            t++;
        }

        return position;
    }





    public void SpawnObjects()
    {

        Rebuild();
        int count = GetObjectCount(maxSpawnQuantity, minSpawnQuantity, timespan);


        for (int i = 0; i < count; i++)
        {
            GameObject spawn = GameObject.Instantiate(objecttoSpawn, transform.position, transform.rotation, transform);
            spawn.transform.position = GetPosition();
            listToSpawn.Add(spawn);


        }

    }
}