using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack1Behavior : StateMachineBehaviour {

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        //PlayerAttack playerAttack = animator.GetComponent<PlayerAttack>();

        //Debug.Log(playerAttack.basicComboCount);
        /*if (playerAttack.basicComboCount >= 2) {
            Debug.Log("Attack 2 Time");
            animator.SetTrigger("Attack2");
        }*/
    }
}
