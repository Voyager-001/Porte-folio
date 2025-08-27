using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager s_instance;
    public static PlayerManager Instance { get { return s_instance; } }

    [SerializeField] private Transform _spawnPoint;
    public Transform SpawnPoint => _spawnPoint; 
    private List<GameObject> _playerList = new();
    public List<GameObject> PlayerList => _playerList;
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
}
