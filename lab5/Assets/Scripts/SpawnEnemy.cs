using UnityEngine;
[System.Serializable]
public class Wave
{
    public int primaryEnemy;
    public int fastEnemy;
    public int fatEnemy;
    public float spawnInterval;
}
public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] points;
    [SerializeField] private Wave[] waves;
    private GameContoler gameContoler;
    private int countEnemy;
    private int spawnedEnemy;
    private float lastSpawnTime;
    private int typeEnemy = 0;
    private int enemyCounter = 0;
    private float timeBetweenWaves = 5;
    void Start()
    {
        gameContoler = gameObject.GetComponent<GameContoler>();
        lastSpawnTime = Time.time;
    }
    void Update()
    {
        if (!gameContoler.gameOver)
        {
            int currentWave = gameContoler.currentWave;
            if (currentWave < waves.Length)
            {
                int maxEnemies = waves[currentWave].primaryEnemy +
               waves[currentWave].fastEnemy + waves[currentWave].fatEnemy;
                switch (typeEnemy)
                {
                    case 0: countEnemy = waves[currentWave].primaryEnemy; break;
                    case 1: countEnemy = waves[currentWave].fastEnemy; break;
                    case 2: countEnemy = waves[currentWave].fatEnemy; break;
                }
                float timeInterval = Time.time - lastSpawnTime;
                float spawnInterval = waves[currentWave].spawnInterval;
                if (((spawnedEnemy == 0 && timeInterval > timeBetweenWaves) || (spawnedEnemy != 0 && timeInterval > spawnInterval)) && enemyCounter < countEnemy)
                {
                    lastSpawnTime = Time.time;
                    GameObject newEnemy = Instantiate(enemies[typeEnemy],
                    spawnpoint.position, Quaternion.identity);
                    newEnemy.GetComponent<Enemy>().points = points;
                    enemyCounter++;
                    spawnedEnemy++;
                    if (enemyCounter >= countEnemy)
                    {
                        typeEnemy++;
                        enemyCounter = 0;
                    }
                }
                if (spawnedEnemy >= maxEnemies && GameObject.FindGameObjectWithTag("Enemy")
               == null)
                {
                    gameContoler.currentWave++;
                    gameContoler.gold = Mathf.RoundToInt(gameContoler.gold * 1.1f);
                    spawnedEnemy = 0;
                    enemyCounter = 0;
                    typeEnemy = 0;
                    lastSpawnTime = Time.time;
                }
            }
            else
            {
                gameContoler.gameWon = true;
            }
        }
    }
}