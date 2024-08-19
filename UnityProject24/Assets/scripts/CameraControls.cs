using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform target; // The transform the camera will follow; ASSIGN IN EDITOR
    public Vector3 posOffset = new Vector3(0, 2, -5); // Default offset behind the player
    public float rotationSpeed = 5.0f; // Speed of the camera rotation based on mouse movement
    public float verticalClamp = 80.0f; // Max vertical angle of the camera

    private float yaw = 0.0f; // Rotation around the y-axis
    private float pitch = 0.0f; // Rotation around the x-axis

    private void LateUpdate()
    {
        if (target == null) return;

        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Update rotation angles based on mouse input
        yaw += mouseX * rotationSpeed;
        pitch -= mouseY * rotationSpeed; // Negative to invert the pitch

        // Clamp the pitch to prevent the camera from flipping over
        pitch = Mathf.Clamp(pitch, -verticalClamp, verticalClamp);

        // Calculate the desired position and rotation of the camera
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position - rotation * Vector3.forward * posOffset.z + Vector3.up * posOffset.y;

        // Update the camera position and rotation
        transform.position = desiredPosition;
        transform.LookAt(target.position);
    }
}
