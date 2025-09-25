using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemyBehaviour : EnemyBehaviour
{
    [SerializeField] private EnemyMovements _enemyMovements;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _doorDamage = 1; 
    private bool _canExplode = true;

    protected override void Attack()
    {
        GameManager.Instance.Door.GetComponent<DoorHealth>().TakeDamage(_doorDamage);
        Death();
    }

    private void OnEnable()
    {
        _enemyMovements.PlayerReached += Explode;
        _enemyMovements.DoorReached += Attack;
    }

    private void OnDisable()
    {
        _enemyMovements.PlayerReached -= Explode;
        _enemyMovements.DoorReached -= Attack;
    }
    private void Explode(PlayerHealth player)
    {
        if (!_canExplode) return;
        _canExplode = false;
        player.TakeDamage(_damage);
        player.GetComponent<PlayerGun>().Refill(ElementType.Water);
        Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}