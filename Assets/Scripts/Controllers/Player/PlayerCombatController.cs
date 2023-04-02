using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.ValueObjects;

public class PlayerCombatController : MonoBehaviour
{
    //for the future installment
    //[SerializeField] private bool _isdead;

    private PlayerCombatData _playerData;
    private EnemyCombatData _enemyData;

    public Collider collider1;
    public Collider collider2;

    private bool _isHit = false;

    internal void SetData(PlayerCombatData playerCombatData,EnemyCombatData enemyCombatData)
    {
        _enemyData = enemyCombatData;
        _playerData = playerCombatData;
    }

    void Update()
    {
        //HitReset();
        CheckCollisions();
    }

    public bool DealDamage(int health,int dmg)
    {
        int _health = health;
        int _dmg = dmg;

        _health -= _dmg; 

        //Debug.Log(_health);

        if (_health <= 0)
        {
            _health = 0;
            return true;
        }
        else
            return false;
    }

    public void OnPlayerAttack()
    {
        DealDamage(_enemyData.Health,_playerData.Damage);
        //Debug.Log("enemy health is " + _enemyData.Health);
    }
    public void OnEnemyAttack()
    {
        DealDamage(_playerData.Health, _enemyData.Damage);
    }

    void CheckCollisions()
    {

        if (collider1.bounds.Intersects(collider2.bounds))
        {
            //Debug.Log("Collision detected!");
            OnPlayerAttack();
            _isHit = true;
        }
    }

    /*IEnumerator HitReset()
    {
        if (!_isHit)
        {
            CheckCollisions();

        }else if (_isHit)
        {
            yield return new WaitForSeconds(2f);
            _isHit = false;
        }
    }*/
}
