using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour
{
    Rigidbody rb;
    public float playerWalk = 2.0f;
    public float playerSprint = 1.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movePlayer = transform.right * x + transform.forward * z;

        float playerSpeed = playerWalk;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed *= playerSprint;
        }

        rb.MovePosition(transform.position + movePlayer.normalized * playerSpeed * Time.deltaTime);
    }
}
