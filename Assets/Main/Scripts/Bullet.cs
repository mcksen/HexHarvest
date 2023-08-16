using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int shootingRange;

    [SerializeField] private int xRange;






    void Update()
    {
        float currentPosition = transform.parent.position.x;
        float max = currentPosition - xRange;
        float min = currentPosition + xRange;
        float distance = Mathf.Abs(transform.parent.position.z - transform.position.z);
        if (distance > shootingRange)
        {
            transform.position = new Vector3(Random.Range(min, max), transform.position.y, transform.parent.position.z);
            float dis = Mathf.Abs(transform.parent.position.x - transform.position.x);

        }
    }

}
