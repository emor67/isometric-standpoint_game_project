using Data.UnityObjects;
using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    //public GameObject hudMenu;

    public CD_Player playerSO;
    public CD_Enemy enemySO;

    public TextMeshProUGUI health;
    public TextMeshProUGUI playerAttackPower;
    public TextMeshProUGUI enemyAttackPower;

    private void Update()
    {   
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        
        health.text = "Health: " + playerSO.Data.combatData.Health.ToString();
        playerAttackPower.text = "Your Attack Power: " + playerSO.Data.combatData.Damage.ToString();
        enemyAttackPower.text = "Enemy Attack Power: " + enemySO.Data.combatData.Damage.ToString();   
    }

}
