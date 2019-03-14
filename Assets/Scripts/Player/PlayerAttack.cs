using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private Animator swordAnimator;

    int basicComboCount = 0;
    public int usedComboCount = 0;
    float lastAttackTime = 1f;
    float maxComboDelay = 1f;

    int attackDamage;
    float knockbackForce;
    float knockbackTime;

    private void Start()
    {
        swordAnimator = gameObject.GetComponent<Animator>();
    }

    void Update () {

        if (Time.time - lastAttackTime > maxComboDelay && basicComboCount != 0) {
            Debug.Log("reset now: " + Time.time + " Attack Time: " + lastAttackTime);
            usedComboCount = 0;
            basicComboCount = 0;
            swordAnimator.ResetTrigger("Attack");
            swordAnimator.SetTrigger("Reset");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            PerformAttack();
        }
	}

    public void PerformAttack()
    {
        if (basicComboCount != 4 && !swordAnimator.GetBool("Attack")) {
            lastAttackTime = Time.time;
            basicComboCount++;

            //Attack Animations
            //Debug.Log("Attack Time: " + basicComboCount);
            swordAnimator.SetTrigger("Attack");
        } /* else {
            swordAnimator.ResetTrigger("Attack");
        }
        //Debug.Log(basicComboCount);
 
        //basicComboCount = Mathf.Clamp(basicComboCount, 0, 2);

        if(basicComboCount == 3) {
            swordAnimator.ResetTrigger("Attack");
        }*/
    }

    private void OnTriggerEnter(Collider collider) {
        if (usedComboCount <= 2) {
            attackDamage = 10;
            knockbackForce = 2f;
            knockbackTime = 3f;
        } else {
            attackDamage = 30;
            knockbackForce = 8f;
            knockbackTime = 4f;
        }

        EnemyHealth enemyHealth = collider.gameObject.GetComponent<EnemyHealth>();

        Vector3 hitDirection = collider.transform.position - transform.position;
        hitDirection = hitDirection.normalized;

        if(enemyHealth != null) {
            enemyHealth.TakeDamage(attackDamage);
            enemyHealth.KnockBack(hitDirection, knockbackForce, knockbackTime);
            Debug.Log("Force: " + knockbackForce);
        }
    }
}
