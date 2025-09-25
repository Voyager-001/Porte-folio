using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : Projectile
{
    [SerializeField] private float explosionRange;
    [SerializeField] private float damageDealed;
    [SerializeField] private MaterialPropertyBlock _mpb;
    [SerializeField] private MeshRenderer _meshRenderer;
    private float frameNumber = 64;
    private float frameTime = 0;


    protected override void Start()
    {
        base.Start();
        transform.localScale = new Vector3(explosionRange, explosionRange, explosionRange);
        frameNumber = _mpb.GetFloat("_Columns") * _mpb.GetFloat("_Lines");
    }

    protected override void Update()
    {
        base.Update();
        VFXAnimation();
    }

    private void VFXAnimation()
    {
        frameTime += Time.deltaTime;
        _mpb.SetFloat("Frame", Mathf.Lerp(0, frameNumber, frameTime/lifeTime));
        _meshRenderer.SetPropertyBlock(_mpb);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<Health>(out Health enemy))
            {
                enemy.TakeDamage(damageDealed);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(transform.position, explosionRange / 2);
    }
}
