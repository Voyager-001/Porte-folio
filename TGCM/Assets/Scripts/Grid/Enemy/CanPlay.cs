using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPlay : BehaviorTree.Node
{
    UnitGridCombat _unitGridCombat;
    

    public CanPlay(UnitGridCombat unitGridCombat)
    {
        _unitGridCombat = unitGridCombat;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if (GridCombatSystem.Instance.whoPlay == GridCombatSystem.WhoPlay.Enemy && GridCombatSystem.Instance.index == _unitGridCombat.Index)
        {
            if (_unitGridCombat.delayX)
            {
                _unitGridCombat.delayX = false;
                GameHandler_GridCombatSystem.Instance.SetCameraFollowPosition(_unitGridCombat.GetPosition());
                GameHandler_GridCombatSystem.Instance.Delay(() => { _unitGridCombat.delayY = true; });
            }
            if(_unitGridCombat.delayY) return BehaviorTree.NodeState.SUCCESS;
        }
        return BehaviorTree.NodeState.FAILURE;
    }
}
