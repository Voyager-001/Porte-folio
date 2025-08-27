using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;
    private float _currentSpeed;
    public float CurrentSpeed => _currentSpeed;
    protected float _buffTimer;
    public event Action SpeedChanged;
    private void Awake()
    {
        _currentSpeed = _baseSpeed;
    }

    public void ChangeSpeed(float duration, float speedMultiplier)
    {
        _currentSpeed = _baseSpeed * speedMultiplier;
        _buffTimer = duration;
    }

    private void Update()
    {
        RecoverSpeed();
    }

    private void RecoverSpeed()
    {
        if (_currentSpeed != _baseSpeed)
        {
            if (_buffTimer > 0)
            {
                _buffTimer -= Time.deltaTime;
                return;
            }
            else
            {
                _currentSpeed = _baseSpeed;
                return;
            }
        }
    }
}
