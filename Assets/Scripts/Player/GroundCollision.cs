using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour {

    private PlayerMovement playerMovement;
    private Rigidbody playerRB;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerRB = GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") && playerRB.velocity.y < 0)
        {
            playerMovement.jumpsLeft = 2;
            Debug.Log("Reset Jumps");
        }
    }
}
