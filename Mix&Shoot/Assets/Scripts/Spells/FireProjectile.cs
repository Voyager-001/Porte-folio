using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : Projectile
{
    [SerializeField] private float initialUpForce;
    private float verticalVelocity;
    [SerializeField] private float gravityForce;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float damageDealed;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private AudioPack audioPackFireImpact;
    
    private AudioSource _audioSource;

    protected override void Start()
    {
        base.Start();
        verticalVelocity = initialUpForce;
    }

    protected override void Update()
    {
        transform.position += (transform.forward * horizontalSpeed + transform.up * verticalVelocity) * Time.deltaTime;

        verticalVelocity -= gravityForce * Time.deltaTime;

        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {

        if((other.CompareTag("Ground") || other.CompareTag("Enemy")) && other.GetComponent<VineSpell>() == null)
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.TryGetComponent<Health>(out Health enemy))
                {
                    enemy.TakeDamage(damageDealed);
                }
            }
            
            if(audioPackFireImpact != null) audioPackFireImpact.PlayOn(_audioSource);

            Instantiate(explosionPrefab, transform.position, transform.rotation);

            KillProjectile();
        }
    }
}
