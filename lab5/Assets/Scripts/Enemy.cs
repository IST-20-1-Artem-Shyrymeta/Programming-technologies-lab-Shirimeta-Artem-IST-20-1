using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public int hp = 3;
    public float coinAfterKill = 10;
    public Transform[] points;
    private int currentPoint = 0;
    [SerializeField] private float moveSpeed = 2.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float pathLength;
    private float totalTimeForPath;
    private float lastWaypointSwitchTime;
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
        distanceCalculation();
    }
    private void distanceCalculation()
    {
        //Обчислюємо координати двух точок, між якими буде здійснюватись рух
        startPosition = points[currentPoint].position;
        endPosition = points[currentPoint + 1].position;
        //Визначаємо відстань між ними, та час що буде потрачений на нього
        pathLength = Vector2.Distance(startPosition, endPosition);
        totalTimeForPath = pathLength / moveSpeed;
    }
    private void RotateIntoMoveDirection()
    {
        Vector3 newDirection = (endPosition - startPosition);
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        gameObject.transform.rotation = Quaternion.AngleAxis(rotationAngle,
       Vector3.forward);
    }
    void FixedUpdate()
    {
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition,
       currentTimeOnPath / totalTimeForPath);
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentPoint < points.Length - 2)
            {
                currentPoint++;
                lastWaypointSwitchTime = Time.time;
                distanceCalculation();
                RotateIntoMoveDirection();
            }
        }
    }
}
