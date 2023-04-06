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
        // ��������, �� ������'� ����� �� 0
        if (health <= 0)
        {
            // ���� ������'� ����� �� 0, �� ��������� ��� �� �������� �������� ����������
            Time.timeScale = 0; // ������� ����
            gameOverImage.SetActive(true); // ����� �������� ����������
        }
    }
}

