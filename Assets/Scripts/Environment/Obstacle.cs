using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private float knockBackForce = 12f;
    private float knockBackTime = 0.25f;

    private void OnCollisionEnter(Collision collision) {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

        Vector3 hitDirection = collision.transform.position - transform.position;
        hitDirection = hitDirection.normalized;

        if (health != null)
        {
            health.TakeDamage(5);
            playerMovement.KnockBack(hitDirection, knockBackForce, knockBackTime);
            //hit.transform.position = new Vector3(0, 1, 0);
        }
        if (health.currentHealth <= 0)
        {
            Destroy(playerMovement.gameObject);
        }
    }
}