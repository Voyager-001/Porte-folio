using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalVFX : MonoBehaviour
{
    [SerializeField] private float _portalAnimDuration = 1;
    [SerializeField] private AnimationCurve _portalAnimCurve;
    [SerializeField] private Material _portalMat;
    private bool _activatePortal = false;
    private float _startTime = 0;

    private void OnEnable()
    {
        PortalManager.Instance.PortalActivated += ActivatePortal;
    }

    private void OnDisable()
    {
        PortalManager.Instance.PortalActivated -= ActivatePortal;
    }

    private void Update()
    {
        if (_activatePortal)
        {
            if (Time.time - _startTime < _portalAnimDuration)
            {
                _portalMat.SetFloat("_EmissiveIntensity", _portalAnimCurve.Evaluate((Time.time - _startTime) / _portalAnimDuration));
            }
            else
            {
                _startTime = Time.time;
            }
        }
    }
    public void ActivatePortal()
    {
        if (!_activatePortal)
        {
            _activatePortal = true;
            Invoke(nameof(DeactivatePortal), _portalAnimDuration);
        }
    }
    public void DeactivatePortal()
    {
        _activatePortal = false;
        _portalMat.SetFloat("_EmissiveIntensity", 1);
    }


}
