using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] private BoxCollider2D hitbox;
    [SerializeField] private LayerMask damageableLayer;
    private Animator animator;
    private PlayerInput input;
    private PlayerController controller;


    void Awake()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        controller = GetComponent<PlayerController>();
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
        Collider2D[] hits = Physics2D.OverlapBoxAll(
            hitbox.transform.position,
            hitbox.size,
            0f,
            damageableLayer
        );

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
