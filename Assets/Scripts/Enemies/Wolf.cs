using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    EnemyHealth wolfHealth;

    private void Awake() {
        wolfHealth = GetComponent<EnemyHealth>();
        wolfHealth.currentHealth = 10000;
    }

    private void FixedUpdate() {
        
    }
}
