using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float movementFactor;
    private Rigidbody2D rb;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Direction.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(joystick.Direction.y, joystick.Direction.x) * Mathf.Rad2Deg;
            UpdateAnimationDirection(angle);
        }
        transform.Translate(joystick.Direction * movementFactor * Time.deltaTime);
        // rb.velocity = new Vector2(joystick.Direction.x * movementFactor, joystick.Direction.y * movementFactor);
    }

    void UpdateAnimationDirection(float angle)
    {
        if (angle > -22.5f && angle <= 67.5f)
        {
            animator.Play("Walk_R"); // Right
        }
        else if (angle > 67.5f && angle <= 157.5f)
        {
            animator.Play("Walk_B"); // Up
        }
        else if (angle > 157.5f || angle <= -112.5f)
        {
            animator.Play("Walk_L"); // Left
        }
        else if (angle > -112.5f && angle <= -22.5f)
        {
            animator.Play("Walk_F"); // Down
        }
    }
}
