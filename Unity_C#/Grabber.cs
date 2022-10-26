using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    RaycastHit grip;
    float reachDistance = 10;
    GameObject heldObject;
    public Transform holdDistance;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F) && Physics.Raycast(transform.position, transform.forward, out grip, reachDistance) && grip.transform.GetComponent<Rigidbody>())
        {
            heldObject = grip.transform.gameObject;
        }
        else if (Input.GetKey(KeyCode.R))
        {
            heldObject = null;
        }
        if (heldObject)
        {
            heldObject.GetComponent<Rigidbody>().velocity = 10 * (holdDistance.position - heldObject.transform.position);
        }
    }
}
