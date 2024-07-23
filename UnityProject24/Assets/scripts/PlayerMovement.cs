using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f; // Variable to control how fast the player moves
    public float jumpForce = 5f; // Variable to control the jump height
    public float gravity = 9.8f; // Variable to control the gravity effect
    public CharacterController controller; // Reference to the CharacterController component on the player
    public Animator animator; // Reference to the Animator component on the player
    private Vector3 movementDirection; // Stores the player's movement direction
    private bool isJumping; // Stores whether the player is currently jumping
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController component attached to the player
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Stores the Horizontal (Left & Right) input of the player
        float verticalInput = Input.GetAxis("Vertical"); // Stores the Vertical (Forward & Backward) input of the player
        // Check if the player is on the ground
        if (controller.isGrounded)
        {
            movementDirection = new Vector3(horizontalInput, 0f, verticalInput); // Calculate the direction the player should move based on the input
            movementDirection = transform.TransformDirection(movementDirection); // Convert the direction into local space; this means 'forward' will be relative to the direction the player is facing rather than the global 'forward'
            movementDirection *= movementSpeed;
            // Check for jump input
            if (Input.GetButtonDown("Jump"))
            {
                movementDirection.y = jumpForce;
                animator.SetTrigger("Jump"); // Trigger the jump animation
            }
            // Set animator Speed parameter based on movement
            float speed = new Vector3(horizontalInput, 0f, verticalInput).magnitude;
            animator.SetFloat("Speed", speed);
            // Handle running animation
            if (speed > 0 && verticalInput > 0)
            {
                animator.SetBool("isRunning", true); // Trigger the run animation
            }
            else
            {
                animator.SetBool("isRunning", false); // Stop the run animation
            }
        }
        // Apply gravity
        movementDirection.y -= gravity * Time.deltaTime;
        // Move the player with the characterController component
        controller.Move(movementDirection * Time.deltaTime);
    }
}