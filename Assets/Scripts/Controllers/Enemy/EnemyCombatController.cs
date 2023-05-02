using UnityEngine;
using Data.UnityObjects;
using Data.ValueObjects;
using System.Collections;

public class EnemyCombatController : MonoBehaviour
{
    private EnemyCombatData _enemyData;
    private PlayerCombatData _playerData;

    private PlayerCombatController _playerCombatController;

    public CD_Enemy enemySO;

    internal void SetData(PlayerCombatData playerCombatData, EnemyCombatData enemyCombatData)
    {
        _enemyData = enemyCombatData;
        _playerData = playerCombatData;
    }

    private void Start()
    {
        _playerCombatController = FindObjectOfType<PlayerCombatController>();
    }

    public bool TakeDamage(int dmg)
    {
        _enemyData.Health -= dmg;

        enemySO.SetHealth(_enemyData.Health);

        Debug.Log("enemy health is " + _enemyData.Health);

        _playerCombatController.canAttack = false;
        
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

            if(_playerCombatController.canAttack)
            {
                TakeDamage(_playerData.Damage);

                StartCoroutine(AttackResetCoroutine());
            }
        }
    }

    IEnumerator AttackResetCoroutine()
    {
        yield return new WaitForSeconds(4f);

        _playerCombatController.canAttack = true;
    }
}