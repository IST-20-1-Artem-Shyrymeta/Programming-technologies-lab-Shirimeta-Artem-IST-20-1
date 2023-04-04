using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rd : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody2D _rigitbody2D;
    void Start()
    {
        _rigitbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
    
        float right = Input.GetAxis("Horizontal");
        if (right != 0)
        {
            var newPosition = transform.position;
            newPosition += Vector3.right * right * Time.deltaTime * speed;
            _rigitbody2D.MovePosition(newPosition);
        }
    }
}