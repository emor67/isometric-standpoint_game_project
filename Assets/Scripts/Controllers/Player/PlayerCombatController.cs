using System.Collections;
using UnityEngine;
using Data.ValueObjects;
using Data.UnityObjects;

public class PlayerCombatController : MonoBehaviour
{
    private PlayerCombatData _playerData;
    private EnemyCombatData _enemyData;

    private bool _canAttack = true;
    
    [SerializeField] private bool _isShieldOn;

    public CD_Player playerSO;
    internal void SetData(PlayerCombatData playerCombatData,EnemyCombatData enemyCombatData)
    {
        _enemyData = enemyCombatData;
        _playerData = playerCombatData;
    }

    private void Start()
    {
        //initial health
        playerSO.SetHealth(50);
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
            _isShieldOn = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            _isShieldOn = false;
        }
    }

    //shield is on/off checker for: while shield on, player cannot attack
    private bool IsShieldOnCheck()
    {
        if (_isShieldOn)
        {
            _canAttack = false;
            return true;
        }
        else
        {
            _canAttack = true;
            return false;
        }
    }

    //player taking damage and setting its health
    public bool TakeDamage(int dmg)
    {
        if (!IsShieldOnCheck())
        {
            _playerData.Health -= dmg;

            playerSO.SetHealth(_playerData.Health);

            Debug.Log("player health is " + _playerData.Health);

            _canAttack = false;
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
        if (other.gameObject.CompareTag("EnemySword"))
        {
            if (_canAttack)
            {
                TakeDamage(_enemyData.Damage);
                StartCoroutine(AttackResetCoroutine());
            }
            else return;
        }
    }

    IEnumerator AttackResetCoroutine()
    {
        yield return new WaitForSeconds(_playerData.AttackResetDelay);

        _canAttack = true;
    }
}
