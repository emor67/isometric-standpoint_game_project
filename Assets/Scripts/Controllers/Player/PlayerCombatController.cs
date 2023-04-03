using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.ValueObjects;
using Data.UnityObjects;

public class PlayerCombatController : MonoBehaviour
{
    private PlayerCombatData _playerData;
    private EnemyCombatData _enemyData;

    public CD_Player playerSO;
    internal void SetData(PlayerCombatData playerCombatData,EnemyCombatData enemyCombatData)
    {
        _enemyData = enemyCombatData;
        _playerData = playerCombatData;
    }

    private void Awake()
    {
        //initial health
        playerSO.SetHealth(50);
    }

    public bool TakeDamage(int dmg)
    {
        _playerData.Health -= dmg;
        
        playerSO.SetHealth(_playerData.Health);
        
        Debug.Log("player health is " + _playerData.Health);
        
        if (_playerData.Health <= 0)
        {
            _playerData.Health = 0;
            return true;
        }
        else
            return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnDamageTaken(other);
    }

    private void OnDamageTaken(Collider other)
    {
        if (other.gameObject.CompareTag("EnemySword"))
        {
            TakeDamage(_enemyData.Damage);
        }
    }
}
