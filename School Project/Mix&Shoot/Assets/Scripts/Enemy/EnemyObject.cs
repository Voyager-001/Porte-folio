using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct EnemyObject
{
    public GameObject EnemyPrefab;
    public int Weight;

    public EnemyObject(GameObject enemyPrefab, int weight)
    {
        EnemyPrefab = enemyPrefab;
        Weight = weight;
    }
}
