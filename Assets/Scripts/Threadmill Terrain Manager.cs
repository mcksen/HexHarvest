using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Terrain = Ksen.Terrain;

public class ThreadmillTerrainManager : MonoBehaviour
{
    [SerializeField] Terrain singleTerrain;
    private List<Terrain> terrainThreadMillList;
    private float gap;
    private float terrainHeight;
    // Start is called before the first frame update
    void Start()
    {
        terrainHeight = singleTerrain.GetTerrainSize("h");
               
        terrainThreadMillList = SpawnTerrains();
        gap = 0;
        foreach (Terrain t in terrainThreadMillList)
        {
           
            t.transform.position = new Vector3(t.transform.position.x, t.transform.position.y, gap);
            gap += terrainHeight;
        }
    }

    public List<Terrain> SpawnTerrains()
    {
        List<Terrain> terrainList = new List<Terrain>();
        for (int i = 0; i < 4; i++)
        {
            singleTerrain = Instantiate(singleTerrain, new Vector3(0, 0, 0), transform.rotation);
            
            terrainList.Add(singleTerrain);
        }
        return terrainList;

    }
    // Update is called once per frame
    void Update()
    {
        foreach (Terrain t in terrainThreadMillList)
        {
            if (t.transform.position.z<=-terrainHeight)

             {
                t.transform.position = new Vector3(t.transform.position.x, t.transform.position.y, 3f * terrainHeight);
             }
        }
    }
}
