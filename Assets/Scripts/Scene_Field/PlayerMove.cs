﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public int Speed;

    Rigidbody rigidbody;

    Vector3 movement;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Run(h,v);
    }
    void Run(float h, float v) {
        //Debug.Log("keyBoard");
        movement.Set(h, 0, v);
        movement = movement.normalized * Speed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movement);
    }
}
