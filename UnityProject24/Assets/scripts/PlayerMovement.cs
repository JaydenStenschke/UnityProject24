using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f; // Variable to control how fast the player moves
    public float jumpForce = 5f; // Variable to control the jump height
    public float gravity = 9.8f; // Variable to control the gravity effect
    public float rotationSpeed = 700f; // Speed at which the player rotates
    public CharacterController controller; // Reference to the CharacterController component on the player
    public Animator animator; // Reference to the Animator component on the player
    public Camera playerCamera; // Reference to the Camera component

    private Vector3 movementDirection; // Stores the player's movement direction
    private float ySpeed; // Separate y-speed for vertical movement (gravity and jumping)

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>(); // Get the CharacterController component attached to the player
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>(); // Get the Animator component attached to the player
        }
        if (playerCamera == null)
        {
            playerCamera = Camera.main; // Get the main camera if not assigned
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Stores the Horizontal (Left & Right) input of the player
        float verticalInput = Input.GetAxis("Vertical"); // Stores the Vertical (Forward & Backward) input of the player

        // Calculate direction based on camera's orientation
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        forward.y = 0; // Ensure the forward vector is flat on the XZ plane
        right.y = 0; // Ensure the right vector is flat on the XZ plane

        forward.Normalize();
        right.Normalize();

        // Calculate movement direction based on input and camera orientation
        movementDirection = forward * verticalInput + right * horizontalInput;
        movementDirection *= movementSpeed;

        // Check if the player is on the ground
        if (controller.isGrounded)
        {
            // Check for jump input
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpForce; // Apply jump force
                animator.SetTrigger("Jump"); // Trigger the jump animation
            }

            // Set animator Speed parameter based on movement
            float speed = new Vector3(horizontalInput, 0f, verticalInput).magnitude;
            animator.SetFloat("Speed", speed);

            // Handle running animation
            animator.SetBool("isRunning", speed > 0);

            // Rotate the player to face the movement direction
            if (movementDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movementDirection.normalized);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            // Apply gravity when not grounded
            ySpeed -= gravity * Time.deltaTime;
        }

        // Apply vertical movement (gravity and jumping)
        movementDirection.y = ySpeed;

        // Move the player with the CharacterController component
        controller.Move(movementDirection * Time.deltaTime);
    }
}
