using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using BehaviorTree;
using Tree = BehaviorTree.Tree;

public class EnemyBT : Tree
{
    public UnitGridCombat unitGridCombat;

    protected override Node SetupTree()
    {
        Node root = new Sequence(new List<Node>
        {
            new CanPlay(unitGridCombat),
            new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new CanAttack(unitGridCombat),
                    new Attack()
                }),

                new Sequence(new List<Node>
                {
                    new GoToTarget(unitGridCombat)
                })
            })
        });

        return root;
    }
}