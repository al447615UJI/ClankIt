using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private PlayerInput input;
    private Animator animator;

    public bool hasWrench {get; private set;} = false;


    [SerializeField] private Vector2 debugVelocity;

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
            hasWrench = true;
            animator.SetBool("hasWrench", true);
            Destroy(collision.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (!hasWrench)
        {
            // if (input.movement != Vector2.zero)
            // {
            //     animator.Play("Run");

            // }
            // else
            // {
            //     animator.Play("Idle");


            // }

            if (input.movement.x > 0 && sprite.flipX)
            {
                sprite.flipX = false;
            }
            else
            {
                if (input.movement.x < 0 && !sprite.flipX)
                {
                    sprite.flipX = true;
                }
            }

            debugVelocity = rb.linearVelocity;
        }

        else
        {

            // if (input.movement != Vector2.zero)
            // {
            //     animator.Play("WalkWrench");
            // }
            // else
            // {
            //     animator.Play("IdleWrench");


            // }

            if (input.movement.x > 0 && sprite.flipX)
            {
                sprite.flipX = false;
            }
            else
            {
                if (input.movement.x < 0 && !sprite.flipX)
                {
                    sprite.flipX = true;
                }
            }

            debugVelocity = rb.linearVelocity;
        }



    }
    void Update()
    {
        //if (input.isAttacking)
        //{
        //    Debug.Log("atacando!!!!");
        //}
    }


}





