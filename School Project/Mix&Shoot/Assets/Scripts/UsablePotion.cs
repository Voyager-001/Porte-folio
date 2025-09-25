using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsablePotion : UsableObject
{
    [SerializeField] private ElementType _potionType;
    private List<PlayerGun> _playerGunsInRange = new();
    public override bool Use()
    {
        switch (_playerGunsInRange.Count)
        {
            case 0:
                return false;
            case 1:
                return false;
            case 2:
                if (_playerGunsInRange[1] == null)
                {
                    _playerGunsInRange.RemoveAt(1);
                }
                else if (_playerGunsInRange[1].transform == transform.parent)
                {
                    _playerGunsInRange[0].Refill(_potionType);
                }
                else
                {
                    _playerGunsInRange[1].Refill(_potionType);
                }
                Destroy(gameObject);
                return true;
            default:
                int nearestPlayerID = 0;
                float closestDistance = float.MaxValue;
                for (int i = 0; i < _playerGunsInRange.Count; i++)
                {
                    float distance = Vector3.Distance(_playerGunsInRange[i].transform.position, transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        nearestPlayerID = i;
                    }
                }
                _playerGunsInRange[nearestPlayerID].Refill(_potionType);
                Destroy(gameObject);
                return true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerGun playerGun) && !_playerGunsInRange.Contains(playerGun))
        {
            _playerGunsInRange.Add(playerGun);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerGun playerGun))
        {
            _playerGunsInRange.Remove(playerGun);
        }
    }
}
