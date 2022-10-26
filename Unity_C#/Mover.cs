using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float move = -2;
    public GameObject walls;
    bool activated;
    public float wallPosition;
    public float limit;


    void Start()
    {
        
    }
    void Update()
    {
        wallPosition = walls.transform.position.y;
        if (activated == true)
        {
            Vector3 movement = new Vector3(0, move, 0);
            walls.transform.Translate(movement * Time.deltaTime);
            if (wallPosition <= -20)
            {
                move = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            activated = true;
        }
    }
}
