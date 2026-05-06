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
            debugVelocity = rb.linearVelocity;
        } else
        {
            debugVelocity = rb.linearVelocity;
        }
    }

}