using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float lifeTime;
    protected float spawnTime;
    [SerializeField] protected GameObject impactParticleSystem;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Time.time - spawnTime >= lifeTime)
        {
            KillProjectile();
        }
    }

    public virtual void KillProjectile()
    {
        //make disappear effect here
        if(impactParticleSystem != null) Instantiate(impactParticleSystem,transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
