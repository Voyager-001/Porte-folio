using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "SpellContent", menuName = "ScriptableObject/Spell")]
public class SpellContent : ScriptableObject
{
    [SerializeField] private ElementType _type;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _ammo;
    public ElementType Type => _type;
    public float FireRate => _fireRate;
    public int Ammo => _ammo;
}