using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] private BoxCollider2D hitbox;
    //[SerializeField] private LayerMask damageableLayer;
    private Animator animator;
    private PlayerInput input;
    private PlayerController controller;
    private PlayerMovement movement;
    private PlayerMeleeHitbox melee;
   // private BoxCollider2D hitbox;


    void Awake()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        controller = GetComponent<PlayerController>();
        //hitbox = GetComponentInChildren<BoxCollider2D>();
        melee = GetComponentInChildren<PlayerMeleeHitbox>();
        movement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        if (hitbox == null)
        {
            Debug.LogError("The BoxCollider2D hitbox in PlayerActions is not set.");
        }
    }

    void Update()
    {
        if (controller.hasWrench && input.isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        //animacion de atacar
        animator.SetBool("isAttacking", true);
    }

    // Triggered via Animatior event.
    public void EnableAttackHitbox()
    {

        
        // Vector2 hitboxPosition = hitbox.transform.position;

        // Collider2D[] hits = Physics2D.OverlapBoxAll(
        //     new Vector2(hitboxPosition.x + hitbox.offset.x, hitboxPosition.y + hitbox.offset.y),
        //     hitbox.size,
        //     0f,
        //     damageableLayer
        // );

        int direction = movement.isFacingRight? 1 : -1;

        Collider2D[] hits = melee.InitializeHitbox(direction);

        foreach (Collider2D hit in hits)
        {
            IDamageable damageable = hit.GetComponent<IDamageable>();

            if (damageable != null)
            {
                Debug.Log("Doing damage to " + hit.gameObject.name);
                damageable.Damage(damage);
            }
        }
    }

    public void HandleAttackEnd()
    {
        animator.SetBool("isAttacking", false);
    }


}
