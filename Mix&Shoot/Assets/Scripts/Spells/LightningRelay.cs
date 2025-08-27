using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRelay : Projectile
{
    private LightningProjectile lightning;
    public LightningProjectile Lightning { get { return lightning; } set { lightning = value; } }
    [SerializeField] private float maxRange;
    private float currentRange;

    // Start is called before the first frame update
    protected override void Start()
    {
        currentRange = 0f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        currentRange = Mathf.Lerp(0f, maxRange, Mathf.Clamp((Time.time - spawnTime) / lifeTime, 0.0f, 1.0f));
        transform.localScale = new Vector3(currentRange,currentRange,currentRange);
        base.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, currentRange/2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && other.GetComponent<VineSpell>() == null && !lightning.EnemiesTouched.Contains(other.gameObject))
        {
            lightning.AddStrike(other.gameObject, other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
            KillProjectile();
        }
    }
}
