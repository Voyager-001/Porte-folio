using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const float speed = 40f;
    private Action onReachedTargetPosition;

    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    private UnitGridCombat unitGridCombat;
    public static PlayerMove PMInstance;

    private void Start()
    {
        unitGridCombat = GetComponent<UnitGridCombat>();
        PMInstance = this;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if(pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if(Vector3.Distance(transform.position, targetPosition) > 1 )
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;
                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                transform.position = transform.position + moveDir * speed * Time.deltaTime;
            }
            else
            {
                currentPathIndex++;
                if(currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                    if(onReachedTargetPosition != null) onReachedTargetPosition();
                }
            }
        }
    }

    public void StopMoving()
    {
        pathVectorList = null;
    }
    public void StopEnemy(int x)
    {
        if(currentPathIndex >= (x-1))
        {
            StopMoving();
            onReachedTargetPosition();
            GameHandler_GridCombatSystem.Instance.GetGrid().GetGridObject(this.GetPosition()).SetUnitGridCombat(unitGridCombat);
        }
    } 

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition, Action onReachedPosition)
    {
        this.onReachedTargetPosition = onReachedPosition;
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);

        if(pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }
    
    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);

        if(pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }
}
