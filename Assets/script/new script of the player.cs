using UnityEngine;
using UnityEngine.InputSystem; // Required for InputValue

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    [Header("Movement Settings")]
    public float speed = 10f;
    public float sprintMultiplier = 2f;
    public float jumpForce = 5f;

    private bool isSprinting;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // This is called by the Player Input component
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // New Input System method for Sprint
    void OnSprint(InputValue value)
    {
        isSprinting = value.isPressed;
    }

    // New Input System method for Jump
    void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Calculate current speed based on sprinting
        float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * currentSpeed);
        
        // Ground check for jumping
        CheckGrounded();
    }

    void CheckGrounded()
    {
        // Simple raycast to check if ball is on floor
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }
}