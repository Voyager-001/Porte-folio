using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPotionVFX : MonoBehaviour
{
    [SerializeField] private Renderer _potionRenderer;
    [SerializeField] private PlayerGun _playerGun;
    [SerializeField] private float _fillSmoothness;
    private float _fillTarget;
    private MaterialPropertyBlock _mpb;
    [SerializeField] private List<Material> _potionMaterials;

    void Start()
    {
        _mpb = new MaterialPropertyBlock();
    }
    private void OnEnable()
    {
        _playerGun.PlayerRefilled += UpdateMaterial;
    }
    private void OnDisable()
    {
        _playerGun.PlayerRefilled -= UpdateMaterial;
    }
    private void UpdateMaterial(ElementType type)
    {
        _potionRenderer.material = _potionMaterials[(int)type];
    }

    private void Update()
    {
        UpdateFillAmount();
        UpdateFillVisuals();
    }

    void UpdateFillVisuals()
    {
        _potionRenderer.SetPropertyBlock(_mpb);
    }

    void UpdateFillAmount()
    {
        _mpb.SetFloat("_FillAmount", _playerGun.GetPotionFillAmount());
    }
}
