using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PerformAttack();
        }
	}

    public void PerformAttack()
    {
        Debug.Log("Attack");
    }
}
