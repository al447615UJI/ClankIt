using UnityEngine;

public class PlayerMeleeHitbox : MonoBehaviour
{
    private BoxCollider2D hitbox;
    [SerializeField] private LayerMask damageableLayer;
     Vector2 hitboxPosition;


    void Awake()
    {
        hitbox = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        hitboxPosition = hitbox.transform.position;

    }

    public Collider2D[] InitializeHitbox(int direction)
    {

        return Physics2D.OverlapBoxAll(
            new Vector2((hitboxPosition.x + hitbox.offset.x * direction) , hitboxPosition.y + hitbox.offset.y),
            hitbox.size,
            0f,
            damageableLayer
        );
    }

    void OnDrawGizmos()
    {
        if (hitbox != null)
        {
            Gizmos.color = Color.red;
            Vector2 hitboxPosition = hitbox.transform.position;

            Gizmos.DrawWireCube(
                new Vector2(hitboxPosition.x + hitbox.offset.x, hitboxPosition.y + hitbox.offset.y),
                hitbox.size

            );
        }
    }
}
