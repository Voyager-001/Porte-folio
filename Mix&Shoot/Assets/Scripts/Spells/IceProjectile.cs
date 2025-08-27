using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectile : DefaultProjectile
{
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //Reduce enemy speed
        }

        if(other.GetComponent<IceProjectile>() == null && other.GetComponent<VineSpell>() == null) base.OnTriggerEnter(other);
    }
}
