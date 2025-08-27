using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceConeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject iceProjectile;
    [SerializeField] private float maxAngle;
    [SerializeField] private int numberOfProjectile;

    private void Start()
    {
        float angleBetweenProjectile = maxAngle/numberOfProjectile;

        for (int i = 0; i < numberOfProjectile; i++) 
        {
            Instantiate(iceProjectile, transform.position + new Vector3(0, Random.Range(-0.1f, 0.1f), 0), Quaternion.Euler(transform.rotation.eulerAngles.x, (transform.rotation.eulerAngles.y - (maxAngle/2.0f) + (i * angleBetweenProjectile)), transform.rotation.eulerAngles.z));
        }

        Destroy(gameObject);
    }
}
