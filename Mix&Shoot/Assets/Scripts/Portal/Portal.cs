using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Portal : MonoBehaviour
{
    [SerializeField][Range(1, 2)] private int _portalID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != null && other.TryGetComponent(out Teleportable _))
        {
            if (_portalID == 1 && !PortalManager.Instance.Portal1Objects.Contains(other.transform))
            {
                PortalManager.Instance.Portal1Objects.Add(other.transform);
            }
            else if (_portalID == 2 && !PortalManager.Instance.Portal2Objects.Contains(other.transform))
            {
                PortalManager.Instance.Portal2Objects.Add(other.transform);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Teleportable _))
        {
            if (_portalID == 1)
            {
                PortalManager.Instance.Portal1Objects.Remove(other.transform);
            }
            else
            {
                PortalManager.Instance.Portal2Objects.Remove(other.transform);
            }
        }
    }
}
