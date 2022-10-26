using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour
{
    Rigidbody playerBody;
    public float playerWalk = 4.0f;
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
        float AD = Input.GetAxisRaw("Horizontal");
        float WS = Input.GetAxisRaw("Vertical");
        Vector3 playerMove = transform.right * AD + transform.forward * WS;

        float playerSpeed = playerWalk;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed *= playerSprint;
        }

        playerBody.MovePosition(transform.position + playerMove.normalized * playerSpeed * Time.deltaTime);
    }
}
