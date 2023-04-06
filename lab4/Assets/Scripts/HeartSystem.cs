using UnityEngine;
using UnityEngine.UI;


public class HeartSystem : MonoBehaviour
{
    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public int startingHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
    }


        private void Update()
    {

        if (currentHealth > 65)
        {
            Hearts[2].sprite = FullHeart;
        }

        if (currentHealth > 45)
        {
            Hearts[1].sprite = FullHeart;
        }

        if (currentHealth > 0)
        {
            Hearts[0].sprite = FullHeart;
        }

        if (currentHealth <= 65)
        {
            Hearts[2].sprite = EmptyHeart;
        }

        if (currentHealth <= 45)
        {
            Hearts[1].sprite = EmptyHeart;
        }

        if (currentHealth <= 0)
        {
            Hearts[0].sprite = EmptyHeart;
        }

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
               
        if (currentHealth <= 0)
        {
            
            Die();

        }
    }
    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, 100);
    }
    private void Die()
    {
    }

}