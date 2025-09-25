using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : BehaviorTree.Node
{
    bool _testAttack;
    public Attack()
    {
        _testAttack = true;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if (_testAttack)
        {
            _testAttack = false;
            GameManager.fight = 0;
            SceneManager.LoadScene(3);
        }

        return BehaviorTree.NodeState.FAILURE;
    }
}
