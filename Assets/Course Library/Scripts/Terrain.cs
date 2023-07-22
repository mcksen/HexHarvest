using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ksen
{

    public class Terrain : MonoBehaviour
    {

        [SerializeField] private Transform model;
        [SerializeField] private SpawnProgression villageSpawn;
        [SerializeField] private SpawnProgression priestSpawn;

        // Start is called before the first frame update
        private void Start()
        {
            EventManager.instance.onTimeStart += HandleTimeStart;
        }


        private void OnDestroy()
        {
            EventManager.instance.onTimeStart -= HandleTimeStart;
        }


        private void HandleTimeStart()
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

    }
}
