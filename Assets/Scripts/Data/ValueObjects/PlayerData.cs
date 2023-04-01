using System;

namespace Data.ValueObjects
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMovementData movementData;
    }

    [Serializable]
    public struct PlayerMovementData
    {
        public float MovementSpeed;
        public float TurnSpeed;
        public PlayerMovementData(float movementSpeed,float turnSpeed)
        {
            MovementSpeed = movementSpeed;
            TurnSpeed = turnSpeed;
        }
    }

}

