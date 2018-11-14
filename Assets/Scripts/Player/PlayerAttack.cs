using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject sword;
    private Animator swordAnimator;

    private void Start()
    {
        swordAnimator = sword.GetComponent<Animator>();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            PerformAttack();
        }
	}

    public void PerformAttack()
    {
        swordAnimator.SetTrigger("BaseAttack");
    }
}
