﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;

    Vector3 movement;
    Rigidbody playerRigidBody;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0 || v != 0)
        {
            Move(h, v);
        }

    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidBody.MovePosition(transform.position + movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.15F);
    }
}
