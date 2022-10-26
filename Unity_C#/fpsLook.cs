using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsLook : MonoBehaviour
{
    public Transform cam;
    public float verticalSensitivity = 1.0f;
    public float horizontalSensitivity = 1.0f;
    public float lookRotation = 0.0f;
    public float lookLimit = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * horizontalSensitivity * 50 * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * verticalSensitivity * 50 * Time.deltaTime;

        transform.Rotate(0f, x, 0f);

        lookRotation -= y;
        lookRotation = Mathf.Clamp(lookRotation, -lookLimit, lookLimit);
        cam.localEulerAngles = new Vector3(lookRotation, 0f, 0f);
    }
}
