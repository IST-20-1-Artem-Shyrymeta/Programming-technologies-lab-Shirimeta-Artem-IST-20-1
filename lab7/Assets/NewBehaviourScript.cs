using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator anim;
    private int _state;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _state = 3;

            }
            else
            {
                _state = 1;
            }
        }
        else
        {
            _state = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _state = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _state = 4;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _state = 5;
        }
        anim.SetInteger("state", _state);

    }
}
