using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsStance : MonoBehaviour
{
    public float playerNormal = 1.0f;
    public float playerCrouch = 0.5f;
    public float playerLying = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newScale = new Vector3(transform.localScale.x, playerNormal, transform.localScale.z);

        if (Input.GetKey(KeyCode.C))
        {
            newScale.y = playerCrouch;
        }else if (Input.GetKey(KeyCode.X))
        {
            newScale.y = playerLying;
        }

        transform.localScale = newScale;
    }
}
