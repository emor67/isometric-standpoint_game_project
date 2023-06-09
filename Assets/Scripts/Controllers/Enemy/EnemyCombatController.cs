using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    private GeneralCombatController _combatController;

    private void Start()
    {
        _combatController = FindObjectOfType<GeneralCombatController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnDamageTaken(other);
    }

    private void OnDamageTaken(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerSword")){

            _combatController.EnemyTakeAndSet();
        }
    }
}