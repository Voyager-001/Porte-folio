using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField] private Transform _portal1, _portal2;
    private List<Transform> _portal1Objects = new(); 
    private List<Transform> _portal2Objects = new();
    private static PortalManager s_instance;
    public static PortalManager Instance { get { return s_instance; } }

    public List<Transform> Portal1Objects => _portal1Objects;
    public List<Transform> Portal2Objects => _portal2Objects;
    public event Action PortalActivated;


    private void Awake()
    {
        if (s_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_instance = this;
        }
    }

    public void Teleport()
    {
        PortalActivated?.Invoke();
        foreach (Transform t in Portal1Objects)
        {
            if (t.TryGetComponent(out CharacterController ctrlr))
            {
                ctrlr.enabled = false;
                t.position = _portal2.position;
                ctrlr.enabled = true;
            }
        }
        foreach (Transform t in Portal2Objects)
        {
            if (t.TryGetComponent(out CharacterController ctrlr))
            {
                ctrlr.enabled = false;
                t.position = _portal1.position;
                ctrlr.enabled = true;
            }
        }
        _portal1Objects.Clear();
        _portal2Objects.Clear();
    }
}