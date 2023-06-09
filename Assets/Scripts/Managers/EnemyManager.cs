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
            enemySO.DamageMulti(0.6f);
            TeleportToNextLocation();       
        }
    }

    private void TeleportToNextLocation()
    {
        Transform newLocation = teleportLocations[currentLocationIndex +1];

        // Teleport the enemy to the new location
        transform.position = newLocation.position;

        // Update the current location index
        currentLocationIndex = (currentLocationIndex + 1) % teleportLocations.Length;
    }
}