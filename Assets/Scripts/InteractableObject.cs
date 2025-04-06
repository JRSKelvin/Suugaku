using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    public bool isInteracted = false;
    public void Interact() {
        if (isInteracted) return;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true); // Activate each child
            child.transform.parent = null;
        }

        transform.position = new Vector2(transform.position.x + offset.x, transform.position.y + offset.y);
        isInteracted = true;
    }
}
