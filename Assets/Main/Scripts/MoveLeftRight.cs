using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float horizontalInput;



    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");




        transform.position = transform.position + (transform.right * Time.deltaTime * speed * horizontalInput);

    }
}
