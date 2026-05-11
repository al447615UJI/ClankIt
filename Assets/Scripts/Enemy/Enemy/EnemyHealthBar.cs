using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bar;
    private float maxBarSizeX = 1f;
    private float maxBarSizeY = 1f;
    

    public void SetSize(int currentHealth, int maxHealth)
    {
        float newSize = currentHealth * maxBarSizeX / maxHealth;

        if (newSize < 0) newSize = 0;
        else if (newSize > maxBarSizeX) newSize = maxHealth;

        bar.size = new Vector2(newSize, maxBarSizeY);

    }
}
