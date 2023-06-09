using System;

namespace Data.ValueObjects
{
    [Serializable]
    public struct EnemyData
    {
        public EnemyCombatData combatData;
    }

    [Serializable]
    public struct EnemyCombatData
    {
        public int Health;
        public float Damage;

        public EnemyCombatData(int health, float damage)
        {
            Health = health;
            Damage = damage;
        }
        
    }
}
