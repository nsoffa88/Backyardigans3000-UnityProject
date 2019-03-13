using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnimationCounter : StateMachineBehaviour {

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        PlayerAttack playerAttack = animator.GetComponent<PlayerAttack>();

        playerAttack.usedComboCount++;
    }
}
