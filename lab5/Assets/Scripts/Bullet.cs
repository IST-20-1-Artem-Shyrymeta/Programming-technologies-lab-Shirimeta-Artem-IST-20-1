using UnityEngine;
public class Bullet : MonoBehaviour
{
    private GameContoler gameContoler;
    private Vector3 startPosition;
    [SerializeField] public GameObject target;
    private float pathLength;
    private float totalTimeForPath;
    private float startTime;
    private float moveSpeed = 5f;
    void Start()
    {
        gameContoler = GameObject.Find("GameManager").GetComponent<GameContoler>();
        startPosition = gameObject.transform.position;
        startTime = Time.time;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            Enemy enemyDate = target.GetComponent<Enemy>();
            int targetHP = enemyDate.hp--;
            if (targetHP <= 0)
            {
                gameContoler.gold += enemyDate.coinAfterKill;
                Destroy(target);

                AudioSource audioSource = target.GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            }
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            pathLength = Vector2.Distance(startPosition, target.transform.position);
            totalTimeForPath = pathLength / moveSpeed;
            float currentTimeOnPath = Time.time - startTime;
            gameObject.transform.position = Vector2.Lerp(startPosition,
           target.transform.position, currentTimeOnPath / totalTimeForPath);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
