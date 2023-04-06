using UnityEngine;
public class Base : MonoBehaviour
{
    private GameContoler gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameContoler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!gameManager.gameOver)
            {
                gameManager.health--;
            }
            Destroy(collision.gameObject);
        }
    }
}