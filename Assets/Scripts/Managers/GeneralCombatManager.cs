using Data.UnityObjects;
using Data.ValueObjects;
using UnityEngine;

public class GeneralCombatManager : MonoBehaviour
{
    [SerializeField] private PlayerCombatController playerCombatController;
    [SerializeField] private EnemyCombatController enemyCombatController;
    [SerializeField] private GeneralCombatController generalCombatController;

    private EnemyData _enemyData;
    private PlayerData _playerData;

    private void Start()
    {
        
    }

    private void Update()
    {
        _enemyData = GetEnemyData();
        _playerData = GetPlayerData();
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
        generalCombatController.SetData(_playerData.combatData, _enemyData.combatData);
    }
}
