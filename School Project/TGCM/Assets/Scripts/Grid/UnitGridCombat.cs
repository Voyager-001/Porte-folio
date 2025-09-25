using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGridCombat : MonoBehaviour
{
    [SerializeField] private Team team;
    private PlayerMove playerMove;

    public bool canMoveThisTurn;
    public bool canMove;
    public bool canAttackThisTurn;
    public bool canAttack;
    public bool delayX;
    public bool delayY;
    public int reach;
    public int Index;
    public int health;
    public int damage;
    public string indexString;

    public enum Team
    {
        Allie,
        Enemy
    }

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void Start()
    {
        delayX = true;
        delayY = false;
        if(health <= 0)
        {
            GridCombatSystem.Instance.IsDead(indexString);
            Destroy(gameObject);
        }
    }

    public void MoveTo(Vector3 mouseWorldPosition, Action onReachedPosition)
    {
        playerMove.SetTargetPosition(mouseWorldPosition, () =>
        {
            onReachedPosition();
        });
    }

    public void StopEnemy()
    {
        playerMove.StopEnemy(reach);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int setHealth)
    {
        health = setHealth;
    }

    public Team GetTeam()
    {
        return team;
    }

    public bool FinishThisTurn()
    {
        return !canAttackThisTurn && !canMoveThisTurn;
    }

    public bool IsEnemy(UnitGridCombat unitGridCombat)
    {
        return unitGridCombat.GetTeam() != team;
    }

    public bool IsAllie(UnitGridCombat unitGridCombat)
    {
        return unitGridCombat.GetTeam() == team;
    }
}
