using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    float YRotation = 0f;
    float XRotation = 0f;

    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        //control rotation around y axis (Look up and down)
        YRotation += mouseX;

        //applying rotation
        transform.localRotation = Quaternion.Euler(XRotation, YRotation, 0f);

    }
}
