using UnityEngine;

public class BreakableObject : MonoBehaviour, IDamageable
{
    public int maxHealth { get; set; }
    public int currentHealth { get; set; }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
