using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "EnemyWave", menuName = "ScriptableObject/Wave")]
public class EnemyWave : ScriptableObject
{
    //[SerializeField] private List<GameObject> _enemyPrefabList = new List<GameObject>();
    [SerializeField] private float _startDelay;
    [SerializeField] private EnemyObject[] _enemies;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _maxDuration;
    [SerializeField] private float _spawnDelay;
    public float StartDelay => _startDelay;

    public EnemyObject[] Enemies => _enemies;

    public int EnemyCount => _enemyCount;

    public float MaxDuration => _maxDuration;

    public float SpawnDelay => _spawnDelay;
}
