using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningProjectile : Projectile
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject lightningRelay;
    [SerializeField] private float sphereCastThreeshold;

    private bool continueStrike;
    [SerializeField] private int maxEnemyTouched;
    [SerializeField] private float damageDealed;

    private List<GameObject> enemiesTouched = new();
    public List<GameObject> EnemiesTouched { get { return enemiesTouched; } }

    [SerializeField] private GameObject impactParticle;

    protected override void Start()
    {
        continueStrike = false;

        if (Physics.SphereCast(transform.position, sphereCastThreeshold, transform.forward, out RaycastHit hitInfo))
        {
            continueStrike = hitInfo.collider.CompareTag("Enemy");
        }

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hitInfo.point);

        if (continueStrike)
        {
            enemiesTouched.Add(hitInfo.collider.gameObject);
            if (hitInfo.collider.TryGetComponent<Health>(out Health enemy)) enemy.TakeDamage(damageDealed);

            SpawnRelay(hitInfo.point);
        }

        base.Start();
    }

    public void SpawnRelay(Vector3 pos)
    {
        GameObject relay = Instantiate(lightningRelay, pos, transform.rotation);
        relay.GetComponent<LightningRelay>().Lightning = this;
    }

    public void AddStrike(GameObject enemy, Vector3 newTargetPos)
    {
        if (enemy.TryGetComponent<Health>(out Health enemyHP)) enemyHP.TakeDamage(damageDealed);
        spawnTime = Time.time;
        enemiesTouched.Add(enemy);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newTargetPos);

        Instantiate(impactParticle, newTargetPos, transform.rotation);

        if (EnemiesTouched.Count < maxEnemyTouched) 
        {
            SpawnRelay(newTargetPos);
        }
    }

    
}
