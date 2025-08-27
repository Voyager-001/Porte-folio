using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthEnemyBehaviour : EnemyBehaviour
{
    [SerializeField] private EnemyMovements _enemyMovements;
    [SerializeField] private Animator _animator;
    [SerializeField][Range(0.1f, 10)] private float _fireTime = 2;
    private bool _canAttack = false;
    private void OnEnable()
    {
        _enemyMovements.DoorReached += Attack;
    }

    private void OnDisable()
    {
        _enemyMovements.DoorReached -= Attack;
    }
    private void Update()
    {
        Fire();
    }
    public void Fire()
    {
        if (!_canAttack) return;
        if (Time.time - _fireTime > 1)
        {
            GameManager.Instance.Door.GetComponent<DoorHealth>().TakeDamage(_damage);
            _fireTime = Time.time;
            _animator.SetTrigger("Strike");
        }
    }

    protected override void Attack()
    {
        _canAttack = true;
    }
}