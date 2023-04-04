using UnityEngine;
using Data.UnityObjects;
using Data.ValueObjects;
using System.Collections;

public class EnemyCombatController : MonoBehaviour
{
    private int health;
    private EnemyCombatData _enemyData;
    private PlayerCombatData _playerData;

    private bool _canAttack = true;

    public CD_Enemy enemySO;
    internal void SetData(PlayerCombatData playerCombatData, EnemyCombatData enemyCombatData)
    {
        _enemyData = enemyCombatData;
        _playerData = playerCombatData;
    }

    private void Start()
    {
        //initial health
        enemySO.SetHealth(100); 
    }

    public bool TakeDamage(int dmg)
    {
        _enemyData.Health -= dmg;

        enemySO.SetHealth(_enemyData.Health);

        Debug.Log("enemy health is "+ _enemyData.Health);

        _canAttack = false;

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

            if (_canAttack)
            {
                TakeDamage(_playerData.Damage);

                StartCoroutine(AttackResetCoroutine());
            }
        }
    }

    IEnumerator AttackResetCoroutine()
    {
        yield return new WaitForSeconds(5f);

        _canAttack = true;
    }
}