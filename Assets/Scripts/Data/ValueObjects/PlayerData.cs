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
        public float PushForce;
        public PlayerMovementData(float movementSpeed,float turnSpeed,float pushForce)
        {
            MovementSpeed = movementSpeed;
            TurnSpeed = turnSpeed;
            PushForce = pushForce;
        }
    }

}

