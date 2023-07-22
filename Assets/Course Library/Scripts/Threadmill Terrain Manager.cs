using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Terrain = Ksen.Terrain;

public class ThreadmillTerrainManager : MonoBehaviour
{
    [SerializeField] private Terrain singleTerrain;

    [SerializeField] private int terrainQuantity;


    private List<Terrain> terrainThreadMillList = new List<Terrain>();
    private float gap;
    private float terrainHeight;

    // Start is called before the first frame update
    private void Start()
    {
        gap = 0;
        terrainHeight = singleTerrain.GetTerrainSize("h");

        terrainThreadMillList = SpawnTerrains();

    }

    public List<Terrain> SpawnTerrains()
    {
        List<Terrain> terrainList = new List<Terrain>();
        for (int i = 0; i < terrainQuantity; i++)
        {
            Terrain instance = Instantiate(singleTerrain, new Vector3(transform.position.x, transform.position.y, gap), transform.rotation);
            gap += terrainHeight;
            terrainList.Add(instance);
        }
        return terrainList;

    }
    // Update is called once per frame
    private void Update()
    {
        foreach (Terrain t in terrainThreadMillList)
        {
            if (t.transform.position.z <= -terrainHeight)

            {
                t.transform.position = new Vector3(t.transform.position.x, t.transform.position.y, (terrainQuantity - 1) * terrainHeight);
                t.Rebuild();

            }
        }
    }
}
