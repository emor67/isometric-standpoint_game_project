using UnityEngine;
using Data.UnityObjects;
using Data.ValueObjects;
using UnityEditor;

public class EnemyCombatController : MonoBehaviour
{
    private int health;
    private EnemyCombatData _enemyData;
    private PlayerCombatData _playerData;

    public CD_Enemy enemySO;
    internal void SetData(PlayerCombatData playerCombatData, EnemyCombatData enemyCombatData)
    {
        _enemyData = enemyCombatData;
        _playerData = playerCombatData;
    }

    private void Awake()
    {
        //initial health
        enemySO.SetHealth(100); 
    }

    public bool TakeDamage(int dmg)
    {
        _enemyData.Health -= dmg;

        enemySO.SetHealth(_enemyData.Health);

        Debug.Log("enemy health is "+ _enemyData.Health);

        if (_enemyData.Health <= 0)
        {
            _enemyData.Health = 0;
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
        if (other.gameObject.CompareTag("PlayerSword")){
            TakeDamage(_playerData.Damage);
        }
    }

}