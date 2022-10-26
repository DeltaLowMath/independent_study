using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsJump : MonoBehaviour
{
    Rigidbody playerBody;
    public float jumpForce = 0.0f;
    float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform playerFeet;
    public bool singleJump;


    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (singleJump)
        {
            GroundedJump();
        }
        else
        {
            FlyJump();
        }

    }

    void FlyJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void GroundedJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerIsOnGround())
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool PlayerIsOnGround()
    {
        Collider[] colliders = Physics.OverlapSphere(playerFeet.position, groundCheckRadius, groundLayer);

        if (colliders.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
