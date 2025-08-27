using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovements : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Speed _speed;
    public enum EEnemyTarget
    {
        Door,
        Player
    }

    [SerializeField] private EEnemyTarget _target = EEnemyTarget.Door;

    public event Action<PlayerHealth> PlayerReached;

    public event Action DoorReached;

    private void OnEnable()
    {
        _speed.SpeedChanged += OnSpeedChanged;
    }
    private void OnDisable()
    {
        _speed.SpeedChanged -= OnSpeedChanged;
    }

    private void OnSpeedChanged()
    {
        agent.speed = _speed.CurrentSpeed;
    }

    void Start()
    {
        switch(_target)
        {
            case EEnemyTarget.Door:
                agent.SetDestination(GameManager.Instance.Door.position);
                break;
            case EEnemyTarget.Player:
                EvaluateClosestTarget();
                break;
        }
        agent.SetDestination(GameManager.Instance.Door.position);
        agent.speed = _speed.CurrentSpeed;
    }
    private void Update()
    {
        switch (_target)
        {
            case EEnemyTarget.Door:
                break;
            case EEnemyTarget.Player:
                agent.SetDestination(EvaluateClosestTarget().position);
                break;
            default:
                break;
        }
    }

    private Transform EvaluateClosestTarget()
    {
        float closestDistance = float.MaxValue;
        int closestPlayerID = 0;
        for (int i = 0; i < PlayerManager.Instance.PlayerList.Count; i++)
        {
            float currentPlayerDistance = Vector3.Distance(PlayerManager.Instance.PlayerList[i].transform.position, transform.position);
            if (currentPlayerDistance < closestDistance)
            {
                closestDistance = currentPlayerDistance;
                closestPlayerID = i;
            }
        }
        if (closestDistance < Vector3.Distance(GameManager.Instance.Door.position, transform.position))
        {
            return PlayerManager.Instance.PlayerList[closestPlayerID].transform;
        }
        else
        {
            return GameManager.Instance.Door;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DoorHealth door))
        {
            Debug.Log("Door reached");
            DoorReached?.Invoke();
        }
        if (other.TryGetComponent(out PlayerHealth player))
        {
            Debug.Log("Player reached");
            PlayerReached?.Invoke(player);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out DoorHealth door))
        {
            Debug.Log("Door reached");
            DoorReached?.Invoke();
        }
        if (collision.collider.TryGetComponent(out PlayerHealth player))
        {
            Debug.Log("Player reached");
            PlayerReached?.Invoke(player);
        }
    }
}
