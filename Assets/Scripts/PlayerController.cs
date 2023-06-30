using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float horizontalInput;

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
        transform.Translate(Vector3.forward * Time.deltaTime * speed* horizontalInput);
    }
    
}
