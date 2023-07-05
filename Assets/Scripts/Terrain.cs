using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ksen
{

    public class Terrain : MonoBehaviour
    {

        [SerializeField] private Transform model;
        [SerializeField] private SpawnRandomObjects villageSpawn;
        [SerializeField] private SpawnRandomObjects priestSpawn;


        // Start is called before the first frame update
        void Awake()
        {
            Rebuild();
        }


        public float GetTerrainSize(string side)
        {
            float size = 0;
            if (side == "w")
            {
                size = model.localScale.x;
            }
            if (side == "h")
            {
                size = model.localScale.y;
            }
            return size;
        }

        public void Rebuild()
        {
            villageSpawn.SpawnObjects();
            priestSpawn.SpawnObjects();
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
