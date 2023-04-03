using Data.UnityObjects;
using Data.ValueObjects;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private PlayerCombatController playerCombatController;
    [SerializeField] private EnemyCombatController enemyCombatController;

    private EnemyData _enemyData;
    private PlayerData _playeData;

    private void Update()
    {
        _enemyData = GetEnemyData();
        _playeData = GetPlayerData();
        SendDataToControllers();
    }

    private PlayerData GetPlayerData()
    {
        return Resources.Load<CD_Player>("Data/CD_Player").Data;
    }

    private EnemyData GetEnemyData()
    {
        return Resources.Load<CD_Enemy>("Data/CD_Enemy").Data;
    }

    private void SendDataToControllers()
    {
        playerCombatController.SetData(_playeData.combatData,_enemyData.combatData);
        enemyCombatController.SetData(_playeData.combatData, _enemyData.combatData);
    }

}