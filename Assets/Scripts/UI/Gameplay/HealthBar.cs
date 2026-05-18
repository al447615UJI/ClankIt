using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bar;
    [SerializeField] private float maxBarSizeX = 1f;
    [SerializeField] private float maxBarSizeY = 1f;
    

    public void SetSize(int currentHealth, int maxHealth)
    {
        float newSize = currentHealth * maxBarSizeX / maxHealth;

        if (newSize < 0) newSize = 0;
        else if (newSize > maxBarSizeX) newSize = maxHealth;

        bar.size = new Vector2(newSize, maxBarSizeY);

    }
}
