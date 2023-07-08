//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{

//    [SerializeField] float xRangeMin;
//    [SerializeField] float xRangeMax;
//    private GameObject currentCollidingObj;
//    private bool isColliding = false;

//    private void OnTriggerEnter(Collider other)

//    {
//        if (other.gameObject.layer == LayerMask.NameToLayer("Village"))
//        {
//            currentCollidingObj = other.gameObject;
//            isColliding = true;
//        }
//        Debug.Log("enter");
//        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
//        {
//            //player gets damage

//        }

//    }


//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.layer == LayerMask.NameToLayer("Village"))
//        {
//            isColliding = false;
//        }

//    }


//    // Update is called once per frame
//    void Update()
//    {
//        if (transform.position.x <= xRangeMin)
//        {
//            transform.position = new Vector3(xRangeMin, transform.position.y, transform.position.z);
//        }
//        if (transform.position.x >= xRangeMax)
//        {
//            transform.position = new Vector3(xRangeMax, transform.position.y, transform.position.z);
//        }
//        if (Input.GetKey(KeyCode.Space) && isColliding)
//        {
//            EventManager.TryCollectyInfant(currentCollidingObj);
//        }



//    }

//}
