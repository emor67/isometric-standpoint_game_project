using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEffectsController : MonoBehaviour
{
    private GeneralCombatController _combatController;

    private void Awake()
    {
        _combatController = FindObjectOfType<GeneralCombatController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthPotion"))
        {
            _combatController.HealthPotion();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("DmgmultiPotion"))
        {
            _combatController.DamageMultiplier();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("TakenDmgMultiPotion"))
        {
            _combatController.TakenDamageMultiplier();
            Destroy(other.gameObject);
        }
    }
}
