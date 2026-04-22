using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private PlayerInput input;
    private Animator animator;

    private bool hasWeapon = false;

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wrench"))
        {
            hasWeapon = true;
            collision.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (!hasWeapon)
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

        else
        {
            Vector2 movimiento = input.movement;

            rb.linearVelocity = movimiento * velocidad;

            if (movimiento != Vector2.zero && !isMoving)
            {
                animator.Play("WalkWrench");
                isMoving = true;
            }
            else if (movimiento == Vector2.zero && isMoving)
            {
                animator.Play("IdleWrench");
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



    }
    void Update()
    {
    
    }


}





