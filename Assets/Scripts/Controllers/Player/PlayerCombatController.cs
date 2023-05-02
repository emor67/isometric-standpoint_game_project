using UnityEngine;
using Data.ValueObjects;

public class PlayerCombatController : MonoBehaviour
{
    private GeneralCombatController _combatController;
   
    public bool isShieldOn;
    public bool canAttack = true;

    private void Awake()
    {
        _combatController = FindObjectOfType<GeneralCombatController>();
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

    private void OnTriggerEnter(Collider other)
    {
        OnDamageTaken(other);
    }

    private void OnDamageTaken(Collider other)
    {
        if (other.gameObject.CompareTag("EnemySword")){

            if(canAttack)
            {
                _combatController.PlayerTakeAndSet();
            }
        }
    }

}
