using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsWalkable : MonoBehaviour
{
    private void Start()
    {
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(9, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(9, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 0).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 0).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 0).isWalkable);
        
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 1).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 1).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 1).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 2).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 2).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 2).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 2).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 2).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 2).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 2).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 2).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 2).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 2).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 2).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 2).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 2).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 2).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 2).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 2).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 2).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 2).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 2).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 2).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 3).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 3).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 3).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 3).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 3).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 3).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 3).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 3).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 3).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 3).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 3).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 3).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 4).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 4).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 4).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 4).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 4).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 4).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 5).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 5).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 6).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 6).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 6).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 6).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 6).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 6).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 7).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 7).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 7).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 7).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 7).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 7).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 8).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 8).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 8).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 8).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 8).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 8).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 9).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 9).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 9).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 9).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 9).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 9).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 9).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 9).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 10).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 10).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 10).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 10).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 10).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 10).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(10, 10).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(10, 10).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(11, 10).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(11, 10).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(12, 10).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(12, 10).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 11).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 11).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 11).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 11).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 11).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 11).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(9, 11).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(9, 11).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(10, 11).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(10, 11).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(11, 11).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(11, 11).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(12, 11).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(12, 11).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 11).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 11).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 11).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 11).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 12).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 12).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 12).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 12).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(9, 12).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(9, 12).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(10, 12).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(10, 12).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(11, 12).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(11, 12).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(12, 12).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(12, 12).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 12).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 12).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 12).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 12).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 12).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 12).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(9, 13).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(9, 13).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(10, 13).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(10, 13).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(11, 13).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(11, 13).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(12, 13).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(12, 13).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 13).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 13).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 13).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 13).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 13).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 13).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 13).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 13).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(10, 14).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(10, 14).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(11, 14).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(11, 14).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(12, 14).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(12, 14).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 14).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 14).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 17).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 17).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 17).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 17).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 17).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 17).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 18).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 18).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 18).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 18).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 18).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 18).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 18).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 18).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 18).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 18).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 18).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 18).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 18).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 18).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 18).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 18).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 18).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 18).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 18).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 18).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 19).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 19).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 19).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 20).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 20).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 20).isWalkable);

        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(0, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(1, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(2, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(3, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(4, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(5, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(6, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(7, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(8, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(13, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(14, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(15, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(16, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(17, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(18, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 21).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(19, 21).isWalkable);
        GameHandler_GridCombatSystem.Instance.GetWalkableTilemap().SetIsWalkable();
    }
}
