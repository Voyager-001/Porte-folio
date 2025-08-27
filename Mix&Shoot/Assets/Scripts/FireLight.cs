using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    [SerializeField] private Light _fireLight;
    [SerializeField] private float _intensity = 0.5f;
    [SerializeField] private float _flickeringSpeed = 1f;
    [SerializeField] private float _flickeringIntensity = 0.1f;

    private void Start()
    {
        if ( _fireLight == null )
            _fireLight = GetComponent<Light>();
    }
    void Update()
    {
        _fireLight.intensity = Mathf.Lerp(_intensity, _intensity * Mathf.PerlinNoise1D(Time.time * _flickeringSpeed + transform.position.x + transform.position.z + transform.position.y), _flickeringIntensity);
    }
}