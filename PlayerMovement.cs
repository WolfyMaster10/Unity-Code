using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public Rigidbody rb;
    public float movementSpeed = 30f;
    public float jumpForce = 10f;
    public bool isGrounded = true;

    void FixedUpdate()
    {
        // Get the camera's forward and right directions
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 movementDirection = Vector3.zero;

        // Make Forward based on the camera rotation 
        if (Input.GetKey("w"))
        {
            movementDirection += cameraForward;
        }

        // Make Backward based on the camera rotation 
        if (Input.GetKey("s"))
        {
            movementDirection -= cameraForward;
        }

        // Make Left based on the camera rotation 
        if (Input.GetKey("a"))
        {
            movementDirection -= cameraRight;
        }

        // Make Backward based on the camera rotation 
        if (Input.GetKey("d"))
        {
            movementDirection += cameraRight;
        }

        // Add the movement force to the rigidbody
        rb.AddForce(movementDirection * movementSpeed, ForceMode.Acceleration);

        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Apply jump force if the player is grounded and the jump button is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
