using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour
{
    Rigidbody playerBody;

    [Header("Player Speed")]
    public float playerWalk = 5.0f;
    public float playerSprint = 2.0f;
    

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float sideWays = Input.GetAxisRaw("Horizontal");
        float wardWays = Input.GetAxisRaw("Vertical");
        Vector3 playerMove = transform.right * sideWays + transform.forward * wardWays;

        float playerSpeed = playerWalk;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed *= playerSprint;
        }

        playerBody.MovePosition(transform.position + playerMove.normalized * playerSpeed * Time.deltaTime);
    }
}
