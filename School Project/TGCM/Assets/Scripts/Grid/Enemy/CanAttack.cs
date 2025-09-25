using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GridCombatSystem;

public class CanAttack : BehaviorTree.Node
{
    UnitGridCombat _unitGridCombat;
    UnitGridCombat _playerTransform;
    int test;

    public CanAttack(UnitGridCombat unitGridCombat)
    {
        _unitGridCombat = unitGridCombat;
        test = 0;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        _playerTransform = GridCombatSystem.Instance.WhoTarget(_unitGridCombat);
        Grid<GridObject> grid = GameHandler_GridCombatSystem.Instance.GetGrid();
        GridObject gridObject = grid.GetGridObject(_playerTransform.transform.position);
        
        if (_unitGridCombat.canAttack)
        {
            test = (test + 1) % 3;
            grid = GameHandler_GridCombatSystem.Instance.GetGrid();
            Pathfinding pathfinding = GameHandler_GridCombatSystem.Instance.pathfinding;
            grid.GetXY(_unitGridCombat.transform.position, out int unitX, out int unitY);

            GameHandler_GridCombatSystem.Instance.GetTilemap().SetAllTilemapSprite(Tilemap.TilemapObject.TilemapSprite.None);

            for (int x = 0; x < grid.GetWidth(); x++)
            {
                for (int y = 0; y < grid.GetHeight(); y++)
                {
                    grid.GetGridObject(x, y).SetIsValidMovePosition(false);
                }
            }

            int maxMoveDistance = _unitGridCombat.reach;
            for (int x = 0; x < maxMoveDistance; x++)
            {
                for (int y = 0; y < maxMoveDistance; y++)
                {
                    if (grid.GetGridObject(unitX + x, unitY + y) != null && pathfinding.FindPath(unitX, unitY, unitX + x, unitY + y) != null)
                    {
                        if (pathfinding.FindPath(unitX, unitY, unitX + x, unitY + y).Count <= maxMoveDistance)
                        {
                            GameHandler_GridCombatSystem.Instance.GetTilemap().SetTilemapSprite(unitX + x, unitY + y, Tilemap.TilemapObject.TilemapSprite.Move);
                            grid.GetGridObject(unitX + x, unitY + y).SetIsValidMovePosition(true);
                        }
                    }

                    if (x != 0)
                    {
                        if (grid.GetGridObject(unitX - x, unitY + y) != null && pathfinding.FindPath(unitX, unitY, unitX - x, unitY + y) != null)
                        {
                            if (pathfinding.FindPath(unitX, unitY, unitX - x, unitY + y).Count <= maxMoveDistance)
                            {
                                GameHandler_GridCombatSystem.Instance.GetTilemap().SetTilemapSprite(unitX - x, unitY + y, Tilemap.TilemapObject.TilemapSprite.Move);
                                grid.GetGridObject(unitX - x, unitY + y).SetIsValidMovePosition(true);
                            }
                        }
                    }
                    if (y != 0)
                    {
                        if (grid.GetGridObject(unitX + x, unitY - y) != null && pathfinding.FindPath(unitX, unitY, unitX + x, unitY - y) != null)
                        {
                            if (pathfinding.FindPath(unitX, unitY, unitX + x, unitY - y).Count <= maxMoveDistance)
                            {
                                GameHandler_GridCombatSystem.Instance.GetTilemap().SetTilemapSprite(unitX + x, unitY - y, Tilemap.TilemapObject.TilemapSprite.Move);
                                grid.GetGridObject(unitX + x, unitY - y).SetIsValidMovePosition(true);
                            }
                        }

                        if (x != 0)
                        {
                            if (grid.GetGridObject(unitX - x, unitY - y) != null && pathfinding.FindPath(unitX, unitY, unitX - x, unitY - y) != null)
                            {
                                if (pathfinding.FindPath(unitX, unitY, unitX - x, unitY - y).Count <= maxMoveDistance)
                                {
                                    GameHandler_GridCombatSystem.Instance.GetTilemap().SetTilemapSprite(unitX - x, unitY - y, Tilemap.TilemapObject.TilemapSprite.Move);
                                    grid.GetGridObject(unitX - x, unitY - y).SetIsValidMovePosition(true);
                                }
                            }
                        }
                    }
                }
            }

            if (gridObject.GetUnitGridCombat() != null)
            {
                if (_unitGridCombat != null)
                {
                    if (_unitGridCombat.IsEnemy(gridObject.GetUnitGridCombat()))
                    {
                        if (gridObject.GetIsValidMovePosition())
                        {
                            if (_unitGridCombat.canAttackThisTurn)
                            {
                                _unitGridCombat.canAttackThisTurn = false;
                                _unitGridCombat.canAttack = false;
                                _unitGridCombat.canMove = false;
                                _unitGridCombat.canMoveThisTurn = false;
                                GameManager.whoFight = _unitGridCombat.indexString;
                                GameManager.unitWhoTarget = _playerTransform.Index;

                                foreach (var _unitGridCombat in GridCombatSystem.Instance.unitGridCombatDictionary)
                                {
                                    GameManager.unitDictionaryPosition[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.GetPosition();
                                    GameManager.unitDictionaryHealth[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.health;
                                    GameManager.unitDictionaryDamage[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.damage;
                                }
                                GameManager.whoPlayThisTurn = GridCombatSystem.Instance.whoPlay;
                                GameManager.unitDictionaryCanAttack[_unitGridCombat.indexString] = _unitGridCombat.canAttackThisTurn;
                                GameManager.unitDictionaryCanMove[_unitGridCombat.indexString] = _unitGridCombat.canMoveThisTurn;
                                return BehaviorTree.NodeState.SUCCESS;
                            }
                        }
                        else
                        {
                            // Cannot attack enemy
                        }

                    }
                    else
                    {
                        // Not an enemy
                    }
                }
            }
            else
            {
                // No unit here
            }
            if(test == 2)
            {
                _unitGridCombat.canAttackThisTurn = false;
                foreach (var _unitGridCombat in GridCombatSystem.Instance.unitGridCombatDictionary)
                {
                    GameManager.unitDictionaryPosition[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.GetPosition();
                    GameManager.unitDictionaryHealth[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.health;
                    GameManager.unitDictionaryDamage[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.damage;
                }
                GameManager.unitDictionaryCanAttack[_unitGridCombat.indexString] = _unitGridCombat.canAttackThisTurn;
                GameManager.unitDictionaryCanMove[_unitGridCombat.indexString] = _unitGridCombat.canMoveThisTurn;
            }
            _unitGridCombat.canAttack = false;
        }

        return BehaviorTree.NodeState.FAILURE;
    }
}
