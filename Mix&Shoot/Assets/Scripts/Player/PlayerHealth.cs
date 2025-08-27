using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private float _respawnDelay = 2;
    public override void Die()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        gameObject.SetActive(false);
        _currentHealth = _maxHealth;
        transform.position = PlayerManager.Instance.SpawnPoint.position;
        yield return new WaitForSeconds(_respawnDelay);
        gameObject.SetActive(true);
    }
}
