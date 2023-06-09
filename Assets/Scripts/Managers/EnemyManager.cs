using Data.UnityObjects;
using Data.ValueObjects;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public CD_Enemy enemySO;

    public Transform[] teleportLocations;
    private int currentLocationIndex = 0;

    private void Update()
    {
        if(enemySO.Data.combatData.Health <= 0)
        {
            enemySO.SetHealth(50);
            TeleportToNextLocation();       
        }
    }

    private void TeleportToNextLocation()
    {
        Transform newLocation = teleportLocations[currentLocationIndex];

        // Teleport the enemy to the new location
        transform.position = newLocation.position;

        // Update the current location index
        currentLocationIndex = (currentLocationIndex + 1) % teleportLocations.Length;
    }
}