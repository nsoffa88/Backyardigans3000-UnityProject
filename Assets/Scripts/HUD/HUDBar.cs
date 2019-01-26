using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBar : MonoBehaviour
{

    public float fillAmount = 1;
    public Image content;
    public PlayerHealth health;

    // Update is called once per frame
    void Update() {
        HandleBar();
    }

    private void HandleBar() {
        if (fillAmount != content.fillAmount) {
            content.fillAmount = fillAmount;
        }
    }

    public float Map(float value, float inMax) {
        return value / inMax;
    }

    public void UpdateFillAmount() {
        fillAmount = Map(health.currentHealth, health.maxHealth);
    }
}
