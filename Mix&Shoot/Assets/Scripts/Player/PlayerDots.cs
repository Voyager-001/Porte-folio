using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDots : MonoBehaviour
{
    [SerializeField] private MaterialPropertyBlock _mpb;
    [SerializeField] private Renderer _playerDot;

    private void Start()
    {
        _mpb = new();
        PlayerManager.Instance.PlayerList.Add(gameObject);
        _mpb.SetInt("_PlayerID", PlayerManager.Instance.PlayerList.IndexOf(gameObject));
        _playerDot.SetPropertyBlock(_mpb);
    }
}
