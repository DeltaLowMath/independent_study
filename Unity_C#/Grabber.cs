using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public RaycastHit grip;
    float reachDistance = 10;
    GameObject heldObject;
    public Transform holdDistance;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Reach(); 
        }
        else if (Input.GetKey(KeyCode.R))
        {
            heldObject = null;
        }
        if (heldObject)
        {
            Grab();
        }
    }

    void Reach()
    {
        RaycastHit grip = new RaycastHit();
        var reachable = Physics.Raycast(
            transform.position,
            transform.forward,
            out grip,
            reachDistance
            );

        if (reachable && grip.transform.GetComponent<Rigidbody>())
        {
            heldObject = grip.transform.gameObject;
        }
    }

    void Grab()
    {
        heldObject.GetComponent<Rigidbody>().velocity = 10 * (holdDistance.position - heldObject.transform.position);
    }
}
