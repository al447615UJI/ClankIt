using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput input;
    private Animator animator;

    
    [SerializeField] private float velocidad = 5f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
}
