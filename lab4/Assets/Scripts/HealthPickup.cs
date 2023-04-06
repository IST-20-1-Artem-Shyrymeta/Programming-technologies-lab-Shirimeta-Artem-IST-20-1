using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 20;
    public int maxHealth = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HeartSystem playerHealth = other.GetComponent<HeartSystem>();
            if (playerHealth.currentHealth < maxHealth)
            {
                playerHealth.IncreaseHealth(healthAmount);
                Destroy(gameObject);
            }
        }
    }
}
