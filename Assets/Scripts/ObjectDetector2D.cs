using System;
using UnityEngine;

public class ObjectDetector2D : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 3f; // How far to detect
    [SerializeField] private LayerMask detectionLayer;

    public static event Action<GameObject> OnObjectDetected;
    public static event Action OnObjectEmpty;

    void Update()
    {
        DetectSurroundingObjects();
    }

    void DetectSurroundingObjects()
    {
        Collider2D[] objectsNearby = Physics2D.OverlapCircleAll(transform.position, detectionRadius, detectionLayer);

        if (objectsNearby.Length == 0)
        {
            OnObjectEmpty?.Invoke();
            return;
        }

        foreach (Collider2D obj in objectsNearby)
        {
            OnObjectDetected?.Invoke(obj.gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius); // Shows detection range in Unity Editor
    }
}
