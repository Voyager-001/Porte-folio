using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] private float _fogStartDistance;
    [SerializeField] private float _fogEndDistance;
    [SerializeField] private Color _fogColor;
    private FogMode _fogMode = FogMode.Linear;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fog = true;
        RenderSettings.fogEndDistance = _fogEndDistance;
        RenderSettings.fogStartDistance = _fogStartDistance;
        RenderSettings.fogMode = _fogMode;
        RenderSettings.fogColor = _fogColor;
        //RenderSettings.fogDensity = _fogDensity;
        //RenderSettings.fogMode = _fogMode;
       //RenderSettings.fogColor = _fogColor;
    }
}
