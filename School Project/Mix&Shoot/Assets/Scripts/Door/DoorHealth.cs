using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorHealth : Health
{
    private void Start()
    {
        HUDManager.Instance.DoorHealthBar.maxValue = _maxHealth;
        HUDManager.Instance.DoorHealthBar.value = _maxHealth;
    }
    public override void TakeDamage(float damage)
    {
        HUDManager.Instance.DoorHealthBar.value -= damage;
        base.TakeDamage(damage);
    }
    public override void TakeDamage(float damage, ElementType damageType)
    {
        HUDManager.Instance.DoorHealthBar.value -= damage;
        base.TakeDamage(damage, damageType);
    }
    public override void Die()
    {
        GameManager.Instance.GameOver();
    }
}