using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;
    protected float _currentHealth;
    protected bool _canTakeDamage = true;

    void Awake()
    {
        _currentHealth = _maxHealth;
    }
    public virtual void TakeDamage(float damage)
    {
        if (!_canTakeDamage) return;
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _canTakeDamage = false;
            Die();
        }
    }

    public virtual void TakeDamage(float damage, ElementType damageType)
    {
        if (!_canTakeDamage) return;
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _canTakeDamage = false;
            Die();
        }
    }

    public virtual void Die()
    {
        _canTakeDamage = false;
    }
}
