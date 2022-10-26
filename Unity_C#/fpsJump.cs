using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsJump : MonoBehaviour
{
    Rigidbody rb;

    //public Transform groundChecker;
    //public LayerMask groundLayer;

    //public float checkRadius = 0.1f;
    public float jumpForce = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space)) //&& IsOnGround())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        /*
        bool IsOnGround()
        {
            Collider[] colliders = Physics.OverlapSphere(groundChecker.position, checkRadius, groundLayer);

            if (colliders.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */

    }
}
