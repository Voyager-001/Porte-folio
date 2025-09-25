using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : Projectile
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float damageDealed;

    protected override void Update()
    {
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;

        base.Update();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {

            if (other.TryGetComponent(out EnemyHealth enemy))
            {
                enemy.TakeDamage(damageDealed);
            }
        }
        if(!other.CompareTag("Player") && other.GetComponent<VineSpell>() == null) KillProjectile();
    }

    
}
