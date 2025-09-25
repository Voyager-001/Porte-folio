using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private ElementType _enemyType;
    [SerializeField][Range(0, 1000)] private int _scoreWhenKilled = 100;
    [SerializeField][Range(0.5f, 1)] private float _scoreDecreaseFactor = 0.9f;
    [SerializeField] List<MeshRenderer> _renderer;
    private MaterialPropertyBlock _mpb;
    [SerializeField] private GameObject deathParticle;
    public ElementType EnemyType => _enemyType;
    public static event Action EnemyDies;
    private float _startTime;
    private void Start()
    {
        _startTime = Time.time;
        _mpb = new MaterialPropertyBlock();
        foreach (var renderer in _renderer)
        {
            renderer.SetPropertyBlock(_mpb);
        }
    }
    public override void TakeDamage(float damage)
    {
        if (!_canTakeDamage) return;
        _currentHealth -= damage;
        _mpb.SetFloat("_FresnelOpacity", 1);
        foreach (var renderer in _renderer)
        {
            renderer.SetPropertyBlock(_mpb);
        }
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _canTakeDamage = false;
            GameManager.Instance.AddScore((int)(_scoreWhenKilled * Mathf.Pow(_scoreDecreaseFactor, Time.time - _startTime)));
            Die();
        }
    }
    public override void TakeDamage(float damage, ElementType damageType)
    {
        if (_enemyType == damageType || !_canTakeDamage) return;
        _currentHealth -= damage;
        _mpb.SetFloat("_FresnelOpacity", 1);
        foreach (var renderer in _renderer)
        {
            renderer.SetPropertyBlock(_mpb);
        }
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _canTakeDamage = false;

            print("Score when killed = " + _scoreWhenKilled * (int)Mathf.Pow(_scoreDecreaseFactor, Time.time - _startTime));
            GameManager.Instance.AddScore(_scoreWhenKilled * (int)Mathf.Pow(_scoreDecreaseFactor, Time.time - _startTime));
            Die();
        }
    }

    public override void Die()
    {
        Instantiate(deathParticle, transform.position, Quaternion.Euler(0,0,0));
        EnemyDies?.Invoke();
        Destroy(gameObject);
    }
}