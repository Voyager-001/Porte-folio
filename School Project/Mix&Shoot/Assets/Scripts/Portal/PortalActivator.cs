using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivator : MonoBehaviour
{
    [SerializeField] private GameObject _activationParticles;
    public void ActivatePortal()
    {
        PortalManager.Instance.Teleport();
        Instantiate(_activationParticles, transform.position + Vector3.forward, transform.rotation);
    }
}