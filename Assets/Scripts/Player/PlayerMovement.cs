using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput input;
    private Animator animator;

    private bool isFacingRight = true;

    
    [SerializeField] private float velocidad = 5f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.linearVelocity = input.movement * velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocity", rb.linearVelocity.sqrMagnitude);

        if (input.movement.x < 0 && isFacingRight)
        {
            Flip();
        } else if (input.movement.x > 0 && !isFacingRight)
        {
            Flip();
        }
    }

        // Rotates the whole gameObject, not just the sprite
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}
