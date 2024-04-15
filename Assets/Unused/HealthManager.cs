using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 10;


    public void TakeDamage(float damage){
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount/10;
    }

    public void HealDamage(float healing){
        healthAmount += healing;
        healthAmount = Mathf.Clamp(healthAmount, 0, 10);
        healthBar.fillAmount = healthAmount/10;
    }
}
