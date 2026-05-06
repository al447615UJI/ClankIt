using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <=0)
        {
            Destroy(gameObject);
        }
    }
}
