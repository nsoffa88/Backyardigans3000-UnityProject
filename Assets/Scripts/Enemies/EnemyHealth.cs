using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float knockBackCounter;

    Rigidbody enemyRigidbody;

    private void Awake() {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    public void TakeDamage(float amount) {
        currentHealth -= amount;

        if (currentHealth <= 0) {
            currentHealth = 0;
            Debug.Log("Enemy Dead!");
            Destroy(gameObject);
        }
    }

    public void KnockBack(Vector3 direction, float PlayerKnockBackForce, float PlayerKnockBackTime) {
        knockBackCounter = PlayerKnockBackTime;

        Vector3 knockback = (direction * PlayerKnockBackForce);
        knockback.y = 2f;

        enemyRigidbody.velocity = knockback;
    }
}
