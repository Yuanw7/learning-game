using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;        // Drag your Ball here
    public Vector3 offset = new Vector3(0, 5, -10); // Distance from the ball

    [Header("Smooth Settings")]
    public float smoothSpeed = 0.125f; // Adjust for "weight" (0.01 to 1.0)
    public bool lookAtTarget = true;

    void LateUpdate()
    {
        if (target == null) return;

        // 1. Calculate where the camera wants to be
        Vector3 desiredPosition = target.position + offset;

        // 2. Smoothly interpolate between current position and desired position
        // Vector3.Lerp is standard, but SmoothDamp is also great for physics games
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // 3. Apply the position
        transform.position = smoothedPosition;

        // 4. Always keep the ball in the center of the frame
        if (lookAtTarget)
        {
            transform.LookAt(target);
        }
    }
}
