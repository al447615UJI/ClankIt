using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(2);
        }
        Debug.Log("Destroyed by " + collision.gameObject.name);

        Destroy(gameObject);

    }
    void OnDestroy()
    {
        Debug.Log("Bullet Destroy");

    }
}
