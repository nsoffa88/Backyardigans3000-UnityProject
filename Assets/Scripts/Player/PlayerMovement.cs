using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody playerRigidBody;

    //Movement
    float speed = 10f;
    Vector3 movement;

    //Jump
    float jumpForceConst = 8f;
    float fallMultiplier = 2.5f;
    float lowJumpMultiplier = 2f;
    public int jumpsLeft = 2;

    //Dash
    float dashDistance = 30f;
    bool dashReady = true;

    //Knockback
    float knockBackCounter;

    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (knockBackCounter <= 0) {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            //If any input happens, move character. Needed to prevent rotation reset upon no input
            if (h != 0 || v != 0) {
                Move(h, v);
            }

            if (playerRigidBody.velocity.y < 0) {
                playerRigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            } else if (playerRigidBody.velocity.y > 0 && !Input.GetButton("A")) {
                playerRigidBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }

            if (Input.GetButtonDown("B") && dashReady) {
                Dash(h, v);
            }

            if (Input.GetButtonDown("A") && jumpsLeft > 0) {
                Jump();
            }
        } else {
            knockBackCounter -= Time.deltaTime;
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
        jumpsLeft--;
        Debug.Log("Jumps Left: " + jumpsLeft);
    }

    void Dash(float h, float v) {
        playerRigidBody.MovePosition(transform.position + (movement * dashDistance));
    }

    public void KnockBack(Vector3 direction, float EnemyKnockBackForce, float EnemyKnockBackTime) {
        knockBackCounter = EnemyKnockBackTime;

        movement = (direction * EnemyKnockBackForce);
        movement.y = 2f;
        Debug.Log(movement);

        playerRigidBody.velocity = movement;
    }
}
