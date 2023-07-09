using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float xRangeMin;
    [SerializeField] float xRangeMax;

    private void OnTriggerEnter(Collider other)

    {

        Debug.Log("enter");
        Damager damage = other.gameObject.GetComponent<Damager>();
        if (damage != null)
        {
            EventManager.HandleDamageRecieved(damage.Damange);
        }



    }
    private void OnTriggerStay(Collider other)

    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Village"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                EventManager.TryCollectyInfant(other.gameObject);
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Village"))
        {
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= xRangeMin)
        {
            transform.position = new Vector3(xRangeMin, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= xRangeMax)
        {
            transform.position = new Vector3(xRangeMax, transform.position.y, transform.position.z);
        }



    }

}
