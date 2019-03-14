using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    EnemyHealth wolfHealth;
    Animator wolfMouthAnimator;

    public Transform Player;
    int moveSpeed = 5;
    float maxDist = 1.5f;
    float minDist = 2.5f;

    float attackCooldown = 2f;
    float lastAttackTime = 0;

    private void Awake() {
        wolfHealth = GetComponent<EnemyHealth>();
        wolfHealth.currentHealth = 10000;

        wolfMouthAnimator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (wolfHealth.knockBackCounter < Time.time) {
            transform.LookAt(Player);

            if (Vector3.Distance(transform.position, Player.position) >= maxDist) {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }

            if (Vector3.Distance(transform.position, Player.position) <= minDist && (Time.time - lastAttackTime) > attackCooldown) {
                wolfMouthAnimator.SetTrigger("Bite");
                lastAttackTime = Time.time;
            }
        }
    }
}
