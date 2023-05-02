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

        _playerCombatController = FindObjectOfType<PlayerCombatController>();
        _enemyCombatController = FindObjectOfType<EnemyCombatController>();
    }


}
