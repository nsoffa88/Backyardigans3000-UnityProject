using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(50);
            hit.transform.position = new Vector3(0, 1, 0);
        }
        if (health.currentHealth <= 0)
        {
            Destroy(hit);
        }
    }
}
