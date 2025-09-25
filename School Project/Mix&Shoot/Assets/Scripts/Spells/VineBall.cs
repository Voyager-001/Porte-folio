using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineBall : MonoBehaviour
{
    [SerializeField] private VineSpell vine;
    [SerializeField] private float impactDamage;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player") && other.GetComponent<VineSpell>() == null)
        {
            vine.StopProjectile();
        }

        if(other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<Health>(out Health enemy)) 
            { 
                enemy.TakeDamage(impactDamage); 
            }
        }
    }
}
