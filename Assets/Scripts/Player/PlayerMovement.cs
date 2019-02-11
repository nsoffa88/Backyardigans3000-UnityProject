using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody playerRigidBody;

    //Movement
    public float speed;
    Vector3 movement;

    //Jump
    public float jumpForceConst;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public int jumpsLeft;

    //Dash
    public float dashDistance = 30f;
    public bool dashReady = true;

    //Knockback
    public float knockBackCounter;

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

    public void KnockBack(Vector3 direction, float EnemyKnockBackForce, float EnemyKnockBackTimer) {
        knockBackCounter = EnemyKnockBackTimer;

        movement = (direction * EnemyKnockBackForce);
        movement.y = 2f;
        Debug.Log(movement);

        playerRigidBody.velocity = movement;
    }
}
