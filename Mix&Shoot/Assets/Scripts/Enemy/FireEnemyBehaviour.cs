using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyBehaviour : EnemyBehaviour
{
    [SerializeField] private EnemyMovements _enemyMovements;
    [SerializeField] private Animator _animator;
    private EnemyHealth _enemyHealth;
    private bool _canExplode = true;
    protected override void Attack()
    {
        _animator?.SetTrigger("Attack");
        Explode();
    }

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    private void OnEnable()
    {
        _enemyMovements.DoorReached += Attack;
    }

    private void OnDisable()
    {
        _enemyMovements.DoorReached -= Attack;
    }
    private void Explode()
    {
        Debug.Log("Explode");
        if (!_canExplode) return;
        GameManager.Instance.Door.GetComponent<DoorHealth>().TakeDamage(_damage);
        _enemyHealth.Die();
        _canExplode = false;
    }
}