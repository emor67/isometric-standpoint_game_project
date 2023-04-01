using Data.UnityObjects;
using Data.ValueObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovementController movementController;

    private PlayerData _data;

    private void Awake()
    {
        _data = GetPlayerData();
        SendDataToControllers();
    }

    private PlayerData GetPlayerData()
    {
        return Resources.Load<CD_Player>("Data/CD_Player").Data;
    }

    private void SendDataToControllers()
    {
        movementController.SetData(_data.movementData);
    }
    
}
