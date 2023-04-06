using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tower : MonoBehaviour
{
    private GameContoler gameContoler;
    [SerializeField] private int towerLVL = 0;
    [SerializeField] private float goldForLVLUp;
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject[] towers;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private GameObject bullet;
    private void Start()
    {
        gameContoler = GameObject.Find("GameManager").GetComponent<GameContoler>();
        StartCoroutine(Shoot());
    }
    private void OnMouseUp()
    {
        if (gameContoler.gold >= goldForLVLUp && towerLVL < towers.Length - 1)
        {
            gameContoler.gold -= goldForLVLUp;
            towerLVL++;
            GameObject newTower = Instantiate(towers[towerLVL], transform.position,
           Quaternion.identity);
            Destroy(gameObject);
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootInterval);
        if (enemies.Count > 0 && towerLVL > 0)
        {
            GameObject newBullet = Instantiate(bullet, gameObject.transform);
            newBullet.GetComponent<Bullet>().target = enemies[0];
        }
        StartCoroutine(Shoot());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemies.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemies.Remove(collision.gameObject);
    }
}