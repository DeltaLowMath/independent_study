using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsJump : MonoBehaviour
{
    Rigidbody playerBody;

    [Header("Jump Settings")]
    public float jumpForce = 0.0f;
    public bool groundedJump;

    [Header("Single Jump Checker")]
    public LayerMask groundLayer;
    public Transform groundChecker;
    float groundCheckRadius = 1.0f;


    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (groundedJump)
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
        Collider[] colliders = Physics.OverlapSphere(groundChecker.position, groundCheckRadius, groundLayer);

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
