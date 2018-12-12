using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpForceConst;

    public float fallMultiplier;
    public float lowJumpMultiplier;

    Vector3 movement;
    Rigidbody playerRigidBody;

    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //If any input happens, move character. Needed to prevent rotation reset upon no input
        if (h != 0 || v != 0)
        {
            Move(h, v);
        }

        if (playerRigidBody.velocity.y < 0)
        {
            playerRigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            Debug.Log("falling");
        }
        else if (playerRigidBody.velocity.y > 0 && !Input.GetButton("A"))
        {
            playerRigidBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            Debug.Log("Short hop");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("A"))
        {
            Jump();
            //Debug.Log("Jump");
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidBody.MovePosition(transform.position + movement);

        //Player rotation in movement direction
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.15F);
    }

    void Jump()
    {
        playerRigidBody.velocity = Vector3.up * jumpForceConst;
    }
}
