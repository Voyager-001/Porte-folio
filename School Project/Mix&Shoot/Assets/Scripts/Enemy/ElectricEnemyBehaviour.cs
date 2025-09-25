using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectriEnemyBehaviour : EnemyBehaviour
{
    [SerializeField] private EnemyMovements _enemyMovements;
    [SerializeField] private Animator _animator;
    private bool _canExplode = true;
    protected override void Attack()
    {
        //_animator?.SetTrigger("Attack");
        Explode();
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
        Destroy(gameObject);
        _canExplode = false;
    }
}