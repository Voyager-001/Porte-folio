using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerGun : MonoBehaviour
{
    private ElementType _tankType = ElementType.Water;
    [SerializeField] private int _remainingAmmo;
    [SerializeField] private GameObject[] _spellsPrefabs;
    [SerializeField] private Transform _spellOrigin;
    [SerializeField] private SpellContent[] _spellsContents;
    [SerializeField] private Animator _gunAnimator;
    [SerializeField] private AudioPack audioPackWater;
    [SerializeField] private AudioPack audioPackFire;
    [SerializeField] private AudioPack audioPackIce;
    [SerializeField] private AudioPack audioPackLightning;
    [SerializeField] private AudioPack audioPackEarth;
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    
    private AudioSource _audioSource;
    public event Action<ElementType> PlayerRefilled;
    private float _fireTime = 0;
    
    public void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        _audioSource.outputAudioMixerGroup = audioMixerGroup;
    }

    public void Fire()
    {
        if (Time.time - _fireTime > 1 / _spellsContents[(int)_tankType - 1].FireRate && _remainingAmmo > 0)
        {
            // _gunAnimator.SetTrigger("Shoot");
            Instantiate(_spellsPrefabs[(int)_tankType - 1], _spellOrigin.position, _spellOrigin.rotation);
            _remainingAmmo--;
            _fireTime = Time.time;
            
            if (_tankType == ElementType.Water) audioPackWater.PlayOn(_audioSource);
            else if (_tankType == ElementType.Fire) audioPackFire.PlayOn(_audioSource);
            else if (_tankType == ElementType.Ice) audioPackIce.PlayOn(_audioSource);
            else if (_tankType == ElementType.Lightning) audioPackLightning.PlayOn(_audioSource);
            else if (_tankType == ElementType.Earth) audioPackEarth.PlayOn(_audioSource);
        }
    }

    public void Refill(ElementType potionType)
    {
        _tankType = potionType;
        _remainingAmmo = _spellsContents[(int)potionType -1].Ammo;
        PlayerRefilled.Invoke(potionType);
    }

    public float GetPotionFillAmount()
    {
        return _remainingAmmo / (float)_spellsContents[(int)_tankType - 1].Ammo;
    }
}