using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] protected float _damage;
    protected abstract void Attack();
}