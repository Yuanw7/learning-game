using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target")]
    public GameObject player; // Drag your Ball here

    [Header("Settings")]
    public bool useSmoothing = false; // Set to TRUE if you want a "Cinematic" feel
    public float smoothSpeed = 0.125f;
    
    // The distance between the camera and the player
    private Vector3 offset;

    void Start()
    {
        // 1. Calculate the initial offset based on where you placed the Camera in the Scene view
        // This means you don't have to type numbers manually!
        if (player != null)
        {
            offset = transform.position - player.transform.position;
        }
        else
        {
            Debug.LogError("Camera needs a Player target! Drag the Ball into the inspector.");
        }
    }

    // LateUpdate runs AFTER all physics calculations are done
    void LateUpdate()
    {
        if (player == null) return;

        // 2. Calculate where the camera should be
        Vector3 targetPosition = player.transform.position + offset;

        if (useSmoothing)
        {
            // Option A: Smooth Follow (Cinematic but can feel 'heavy')
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
        else
        {
            // Option B: Hard Lock (Crisp, instant response - Best for "Roll-a-Ball")
            transform.position = targetPosition;
        }
    }
}