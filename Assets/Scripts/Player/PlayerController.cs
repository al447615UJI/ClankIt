using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private PlayerInput input;
    private Animator animator;

    [SerializeField] private Vector2 debugVelocity;

    private bool isMoving = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();

    }

    void FixedUpdate()
    {
        Vector2 movimiento = input.movement;

        rb.linearVelocity = movimiento * velocidad;

        if (movimiento != Vector2.zero && !isMoving)
        {
            animator.Play("Run");
            isMoving = true;
        }
        else if (movimiento == Vector2.zero && isMoving)
        {
            animator.Play("Idle");
            isMoving = false;


        }

        if (movimiento.x > 0 && sprite.flipX)
        {
            sprite.flipX = false;
        }
        else
        {
            if (movimiento.x < 0 && !sprite.flipX)
            {
                sprite.flipX = true;
            }
        }

        debugVelocity = rb.linearVelocity;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
