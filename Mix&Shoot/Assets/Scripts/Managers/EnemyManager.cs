using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager s_instance;
    public static EnemyManager Instance { get { return s_instance; } }
    [SerializeField] private bool _endless;
    [SerializeField] private int _endlessStartDifficulty;
    [SerializeField] private int _endlessScalingDifficulty;
    [SerializeField] private List<EnemyWave> _waveList;
    [SerializeField] private Transform[] _enemySpawnPoints;
    [SerializeField] private Vector3 _rotOffset;
    [SerializeField] private Vector3 _posOffset;
    private int _aliveEnemies;
    private int _waveID = 0;
    private void Awake()
    {
        if (s_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_instance = this;
        }
    }
    private void OnEnable()
    {
        EnemyHealth.EnemyDies += OnEnemyKilled;
    }

    private void OnDisable()
    {
        EnemyHealth.EnemyDies -= OnEnemyKilled;
    }
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        int enemySpawned = 0;
        float waveStartTime = Time.time;
        int enemyOffset = 0;
        int additionalWaveID = 0;
        while (_waveID < _waveList.Count || _endless)
        {
            yield return new WaitForSeconds(_waveList[_waveID].StartDelay);
            while (enemySpawned < _waveList[_waveID].EnemyCount + enemyOffset) // Spawn enemies
            {
                (Vector3, Quaternion) posAndRot = GetSpawnPoint();
                Instantiate(GetEnemy(), posAndRot.Item1, posAndRot.Item2, transform);
                enemySpawned++;
                _aliveEnemies++;
                yield return new WaitForSeconds(_waveList[_waveID].SpawnDelay);
            }
            while (Time.time - waveStartTime < _waveList[_waveID].MaxDuration && _aliveEnemies > 0) // Check next wave condition
            {
                yield return null;
                float timer = Time.time - waveStartTime;
                print("TIMER : " + timer);
            }
            waveStartTime = Time.time;
            enemySpawned = 0;
            if (_waveID < _waveList.Count - 1)
            {
                _waveID++;
            }
            else
            {
                additionalWaveID++;
                enemyOffset = additionalWaveID * _endlessScalingDifficulty + _endlessStartDifficulty;
            }
        }
        GameManager.Instance.Victory();
    }

    private (Vector3, Quaternion) GetSpawnPoint()
    {
        int seed = UnityEngine.Random.Range(0, _enemySpawnPoints.Length);
        Vector3 position = _enemySpawnPoints[seed].position + _posOffset;
        Quaternion rotation = Quaternion.Euler(_enemySpawnPoints[seed].eulerAngles + _rotOffset);
        return (position, rotation);
    }

    private GameObject GetEnemy()
    {
        int totalWeight = 0;
        foreach (EnemyObject enemy in _waveList[_waveID].Enemies)
        {
            totalWeight += enemy.Weight;
        }
        int seed = UnityEngine.Random.Range(0, totalWeight);
        int verifiedWeight = 0;
        for (int i = 0; i < _waveList[_waveID].Enemies.Length; i++)
        {
            verifiedWeight += _waveList[_waveID].Enemies[i].Weight;
            if (seed < verifiedWeight)
            {
                return _waveList[_waveID].Enemies[i].EnemyPrefab;
            }
        }
        return null;
    }

    private void OnEnemyKilled()
    {
        _aliveEnemies--;
    }
}
