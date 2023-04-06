using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;
    private float delay = 2f;
    private float lastDamageTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time >= lastDamageTime + delay)
        {
            lastDamageTime = Time.time;
            other.GetComponent<HeartSystem>().TakeDamage(damage);
        }
    }
}
