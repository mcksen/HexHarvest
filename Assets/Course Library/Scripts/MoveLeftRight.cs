using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float horizontalInput;



    void Update()
    {

        //Setting up input
        horizontalInput = Input.GetAxis("Horizontal");


        //Move the witch left and right

        transform.position = transform.position + (transform.right * Time.deltaTime * speed * horizontalInput);

    }
}
