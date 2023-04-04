using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    void Start() { }
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, speed));
        //transform.Rotate((new Vector3(0f, 0f, -speed)) * Time.deltaTime);
    }
}