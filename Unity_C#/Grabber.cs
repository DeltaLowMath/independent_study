using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public RaycastHit reach;
    GameObject grabbableObject;
    public Transform holdDistance;

    float reachDistance = 10;
    float throwVelocity = 10;


    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Grab();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            Release();
        }
        if (grabbableObject)
        {
            Hold();
        }
    }

    void Grab()
    {
        RaycastHit reach = new RaycastHit();
        var reachable = Physics.Raycast(
            transform.position,
            transform.forward,
            out reach,
            reachDistance
            );

        if (reachable && reach.transform.GetComponent<Rigidbody>())
        {
            grabbableObject = reach.transform.gameObject;
        }
    }

    void Hold()
    {
        grabbableObject.GetComponent<Rigidbody>().velocity = 
            throwVelocity * (holdDistance.position - grabbableObject.transform.position);
        grabbableObject.transform.localEulerAngles = Vector3.zero;
        grabbableObject.tag = "Held";
    }

    void Release()
    {
        grabbableObject.tag = "Key";
        grabbableObject = null;
    }
}