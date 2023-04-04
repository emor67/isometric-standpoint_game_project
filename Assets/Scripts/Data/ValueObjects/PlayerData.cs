using System;

namespace Data.ValueObjects
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMovementData movementData;
        public PlayerCombatData combatData;
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

    [Serializable]
    public struct PlayerCombatData
    {
        public int Health;
        public int Damage;
        public float AttackResetDelay;

        public PlayerCombatData(int health,int damage,float attackResetDelay)
        {
            Health = health;
            Damage = damage;
            AttackResetDelay = attackResetDelay;
        }
    }
}

