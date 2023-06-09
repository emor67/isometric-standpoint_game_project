using Data.UnityObjects;
using Data.ValueObjects;
using System.Collections;
using UnityEngine;

public class GeneralCombatController : MonoBehaviour
{
    private PlayerCombatData _playerData;
    private EnemyCombatData _enemyData;
    
    private PlayerCombatController _playerCombatController;
    private EnemyCombatController _enemyCombatController;

    //SO stands for scriptable object
    public CD_Player playerSO;
    public CD_Enemy enemySO;
    
    internal void SetData(PlayerCombatData playerCombatData, EnemyCombatData enemyCombatData)
    {
        _enemyData = enemyCombatData;
        _playerData = playerCombatData;
    }

    private void Start()
    {
        //initial health
        playerSO.SetHealth(50);
        enemySO.SetHealth(50);

        //initial damage
        playerSO.Data.combatData.Damage = 20;
        enemySO.Data.combatData.Damage = 10;

        _playerCombatController = FindObjectOfType<PlayerCombatController>();
        _enemyCombatController = FindObjectOfType<EnemyCombatController>();
    }

    //player taking damage and setting its health
    private bool PlayerTakeDamage(int dmg)
    {
        if (!_playerCombatController.isShieldOn)
        {
            _playerData.Health -= dmg;

            Debug.Log("player health is " + _playerData.Health);

            _playerCombatController.canAttack = false;
        }

        if (_playerData.Health <= 0)
        {
            _playerData.Health = 0;
            return true;
        }
        else
            return false;
    }
    //For diffrent enemy, it will be rearranged
    public bool EnemyTakeDamage(int dmg)
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

    IEnumerator PlayerAttackResetCoroutine()
    {
        yield return new WaitForSeconds(_playerData.AttackResetDelay);

        _playerCombatController.canAttack = true;
    }

    IEnumerator EnemyAttackResetCoroutine()
    {
        yield return new WaitForSeconds(4f);

        _playerCombatController.canAttack = true;
    }

    //Player takes damage and set health
    public void PlayerTakeAndSet()
    {
        PlayerTakeDamage(_enemyData.Damage);
        playerSO.SetHealth(_playerData.Health);
        StartCoroutine(PlayerAttackResetCoroutine());
    }

    public void EnemyTakeAndSet()
    {
        if (_playerCombatController.canAttack)
        {
            EnemyTakeDamage(_playerData.Damage);
            enemySO.SetHealth(_enemyData.Health);
            StartCoroutine(EnemyAttackResetCoroutine());
        }
    }

    ////potions
    
    public void HealthPotion() 
    {
        playerSO.Heal(10);    
    }

    public void DamageMultiplier()
    {
        playerSO.DamageMulti(2);
    }

    public void TakenDamageMultiplier()
    {
        enemySO.DamageMulti(2);
    } 
}
