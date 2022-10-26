using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject walls;
    bool activated;
    float wallPosition;
    float limit = -20f;
    float move = -2f;


    void Update()
    {
        MoveWall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            activated = true;
        }
    }

    void MoveWall()
    {
        if (activated == true)
        {
            Vector3 movement = new Vector3(0, move, 0);
            walls.transform.Translate(movement * Time.deltaTime);
            MoveLimit();
        }
    }

    void MoveLimit()
    {
        wallPosition = walls.transform.position.y;
        if (wallPosition <= limit)
        {
            move = 0;
        }
    }
}
