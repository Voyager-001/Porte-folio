using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField] private float _spawnTime = 1;
    private bool spawned = false;

    private void Start()
    {
        if (prefab != null)
            Spawn();
    }
    
    private void Update()
    {
        if (gameObject.transform.childCount < 2 && !spawned)
        {
            DelayedSpawn();
        }
    }
    
    private GameObject Spawn()
    {
        GameObject newObject = Instantiate(prefab, spawnPoint.transform.position, transform.rotation);
        
        newObject.transform.SetParent(transform);
        
        return newObject;
    }
    
    private void DelayedSpawn()
    {
        StartCoroutine(SpawnDelayed());
        
        spawned = true;
    }

    private IEnumerator SpawnDelayed()
    {
        yield return new WaitForSeconds(_spawnTime);
        
        Spawn();
        
        spawned = false;
    }
}