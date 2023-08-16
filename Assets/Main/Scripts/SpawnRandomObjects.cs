
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnRandomObjects : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float yPosition;
    [SerializeField] private float xRange;
    [SerializeField] private float zRange;



    [SerializeField] private float gap;




    private List<GameObject> listToSpawn = new List<GameObject>();







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
            if (yPosition == 0)
            {
                yPosition = transform.position.y;
            }

            float x = Random.Range(transform.position.x, transform.position.x + xRange);
            float z = Random.Range(transform.position.z, transform.position.z + zRange);
            Vector3 tryPosition = new Vector3(x, yPosition, z);
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





    public void SpawnObjects(int count)
    {
        Rebuild();



        for (int i = 0; i < count; i++)
        {
            Vector3 pos = GetPosition();
            if (pos != Vector3.zero)
            {
                GameObject spawn = GameObject.Instantiate(objectToSpawn, pos, transform.rotation, transform);

                listToSpawn.Add(spawn);
            }
        }

    }
}
