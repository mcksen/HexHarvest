using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float xRangeMin;
    [SerializeField] float xRangeMax;
    [SerializeField] GameObject model;
    private Vector3 startingPosition;

    // --------------------------------------------------------------------------------------
    // Core functions
    // --------------------------------------------------------------------------------------

    private void Awake()
    {
        startingPosition = transform.position;
        EventManager.instance.onNewGameSelected += HandleNewGameSelected;
    }

    private void Update()
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

    private void OnDestroy()
    {
        EventManager.instance.onNewGameSelected -= HandleNewGameSelected;
    }

    // --------------------------------------------------------------------------------------
    // Event-dependant functions
    // --------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider other)

    {

        Debug.Log("enter");
        Damager damage = other.gameObject.GetComponent<Damager>();
        if (damage != null)
        {
            EventManager.instance.HandleDamageRecieved(damage.Damange);
        }



    }
    private void OnTriggerStay(Collider other)

    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Village"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                EventManager.instance.TryCollectInfant(other.gameObject);
            }
        }

    }

    private void HandleNewGameSelected()
    {
        transform.position = startingPosition;
        model.SetActive(true);
    }
}
