using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    [SerializeField] float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Setting up input
        horizontalInput = Input.GetAxis("Horizontal");


        //Move the witch left and right

        transform.position = transform.position + (transform.right* Time.deltaTime * speed*horizontalInput);

    }
}
