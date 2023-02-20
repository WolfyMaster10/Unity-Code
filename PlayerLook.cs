using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Variables
    
    // Setting the mouse Sensitivity
    public float mouseSensitivity = 100.0f;
    // Creating the clamAngle
    public float clampAngle = 80.0f;

    // rotation around the up/y axis
    private float rotY = 0.0f;
     
    // rotation around the right/x axis
    private float rotX = 0.0f;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        // Getting Y Rotation
        rotY = rot.y;
        // Getting X Rotation
        rotX = rot.x;
        
        // Making X and Y input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
    }

    void Update()
    {
        // Making X and Y input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        // Getting the X and Y
        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
 
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        // Makes it so you can get out of the LockState
         if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }
}
