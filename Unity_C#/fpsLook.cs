using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsLook : MonoBehaviour
{
    public Transform camera;
    float lookRotation = 0.0f;
    float lookLimit = 90.0f;

    [Header("Camera Sensitivity")]
    [Range(1, 10)]
    public float verticalSensitivity;
    [Range(1, 10)]
    public float horizontalSensitivity;
    

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HorizontalLook();
        VerticalLook();
    }

    void HorizontalLook()
    {
        float x = Input.GetAxis("Mouse X") * horizontalSensitivity * 40 * Time.deltaTime;
        transform.Rotate(0f, x, 0f);
    }

    void VerticalLook()
    {
        float y = Input.GetAxis("Mouse Y") * verticalSensitivity * 40 * Time.deltaTime;
        lookRotation -= y;
        lookRotation = Mathf.Clamp(lookRotation, -lookLimit, lookLimit);
        camera.localEulerAngles = new Vector3(lookRotation, 0f, 0f);
    }
}