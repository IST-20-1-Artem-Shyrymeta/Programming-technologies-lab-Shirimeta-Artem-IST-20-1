using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoler : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameWon = false;
    public int health;
    public float gold;
    public int currentWave = 0;


    public GameObject gameOverImage;
    void Update()
    {
        // ѕерев≥рка, чи здоров'€ спадаЇ до 0
        if (health <= 0)
        {
            // якщо здоров'€ спадаЇ до 0, то завершуЇмо гру та показуЇмо картинку завершенн€
            Time.timeScale = 0; // «упинка часу
            gameOverImage.SetActive(true); // ѕоказ картинки завершенн€
        }
    }
}

