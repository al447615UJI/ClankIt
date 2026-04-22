using UnityEngine;

public interface IDamageable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Damage(float damageAmount);

    // Update is called once per frame
    void Die();

    float MaxHealth {get; set;}
    float CurrentHealth {get; set; }
}
