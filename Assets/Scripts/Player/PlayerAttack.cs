using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private Animator swordAnimator;

    int basicComboCount = 0;
    int usedComboCount = 0;
    float lastAttackTime = 1f;
    float maxComboDelay = 1f;

    private void Start()
    {
        swordAnimator = gameObject.GetComponent<Animator>();
    }

    void Update () {

        if (Time.time - lastAttackTime > maxComboDelay && basicComboCount != 0) {
            Debug.Log("reset now: " + Time.time + " Attack Time: " + lastAttackTime);
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
            Debug.Log("Attack Time: " + basicComboCount);
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
}
