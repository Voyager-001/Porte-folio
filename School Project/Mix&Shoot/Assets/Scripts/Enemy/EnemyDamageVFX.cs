using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageVFX : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _renderer;
    [SerializeField] private MaterialPropertyBlock _mpb;
    [SerializeField] private float _animationSpeed;
    private void Update()
    {
        _renderer[0].GetPropertyBlock(_mpb);
        _mpb.SetFloat("_FresnelOpacity", Mathf.Lerp(_mpb.GetFloat("_FresnelOpacity"), 0, _animationSpeed * Time.deltaTime));
        foreach (var renderer in _renderer)
            renderer.SetPropertyBlock(_mpb);

    }
    private void Start()
    {
        _mpb = new MaterialPropertyBlock();
        foreach (var renderer in _renderer)
        {
            renderer.SetPropertyBlock(_mpb);
        }
    }
}
