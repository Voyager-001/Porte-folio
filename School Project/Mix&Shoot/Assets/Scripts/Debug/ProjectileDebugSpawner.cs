using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDebugSpawner : MonoBehaviour
{
    [SerializeField] private GameObject projectileToSpawn;
    [SerializeField] private bool isActive;
    [SerializeField] private float timeBetweenSpawn;
    private float lastSpawnTime;
    [SerializeField] private float rotationSpeed;

    void Start()
    {
        lastSpawnTime = Time.time;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + rotationSpeed * Time.deltaTime, transform.rotation.eulerAngles.z);
        if (isActive && Time.time - lastSpawnTime >= timeBetweenSpawn) 
        {
            Instantiate(projectileToSpawn, transform.position, transform.rotation);
            lastSpawnTime = Time.time;
        }
    }
}
