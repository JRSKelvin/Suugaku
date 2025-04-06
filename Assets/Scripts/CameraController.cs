using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  // Assign player in Inspector
    public float smoothSpeed = 5f; // Adjust for more/less smoothing
    public Vector3 offset = new Vector3(0, 2, -10); // Adjust camera position

    void LateUpdate()
    {
        if (player != null)
        {
            // Target position (player position + offset)
            Vector3 targetPosition = player.position + offset;
            
            // Smoothly move the camera using Lerp
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
