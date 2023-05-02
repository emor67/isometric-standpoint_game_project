using System.Collections;
using UnityEngine;
using Data.ValueObjects;
using Data.UnityObjects;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField] private bool isShieldOn;
    
    private PlayerCombatData _playerData;
    private EnemyCombatData _enemyData;

    public bool canAttack = true;

    public CD_Player playerSO;

    internal void SetData(PlayerCombatData playerCombatData,EnemyCombatData enemyCombatData)
    {
        _enemyData = enemyCombatData;
        _playerData = playerCombatData;
    }

    
    private void Update()
    {
        ShieldOnInput();
    }

    //while right click is down shield up, and right click up(released) shield down
    private void ShieldOnInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isShieldOn = true;
            canAttack = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isShieldOn = false;
            canAttack = true;
        }
    }


    //player taking damage and setting its health
    public bool TakeDamage(int dmg)
    {
        if (!isShieldOn)
        {
            _playerData.Health -= dmg;

            playerSO.SetHealth(_playerData.Health);

            Debug.Log("player health is " + _playerData.Health);

            canAttack = false;
        }
       
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
        //with else if we can add other enemis but it won't be okay so we need better solution 
        if (other.gameObject.CompareTag("EnemySword"))
        {
            if (canAttack)
            {
                TakeDamage(_enemyData.Damage);
                StartCoroutine(AttackResetCoroutine());
            }
            
        }
    }

    IEnumerator AttackResetCoroutine()
    {
        yield return new WaitForSeconds(_playerData.AttackResetDelay);

        canAttack = true;
    }
}
