using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ksen {

    public class Terrain : MonoBehaviour
    {
        private float terrainWidth = 50;
        private float terrainHeight = 50;
        // Start is called before the first frame update
        void Start()
        {

        }
        public float GetTerrainSize(string side)
        {
            float size = 0;
            if (side == "w")
            {
                size = terrainWidth;
            }
            if (side == "h")
            {
                size = terrainHeight;
            }
            return size;
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}
