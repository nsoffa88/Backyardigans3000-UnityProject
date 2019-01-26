using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth = 100;
    public float currentHealth;

    public HUDBar healthBar;

    public void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.UpdateFillAmount();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Q) && (currentHealth + 20) < maxHealth) {
            currentHealth += 20;
            healthBar.UpdateFillAmount();
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            currentHealth = maxHealth;
            healthBar.UpdateFillAmount();
        }
    }
}
