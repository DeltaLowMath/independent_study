using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsStance : MonoBehaviour
{
    public float playerStand = 1.0f;
    public float playerCrouch = 0.5f;
    public float playerProne = 0.1f;
    public float playerStance;


    void Start()
    {
        playerStance = playerStand;
    }

    void Update()
    {
        Vector3 stance = new Vector3(transform.localScale.x, playerStance, transform.localScale.z);

        ChangePlayerStance(stance);
        transform.localScale = stance;
    }

    void ChangePlayerStance(Vector3 stance)
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            stance.y = playerCrouch;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            stance.y = playerProne;
        }
        if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.X))
        {
            stance.y = playerStand;
        }
        playerStance = stance.y;
    }
}
