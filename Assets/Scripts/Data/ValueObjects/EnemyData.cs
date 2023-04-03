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
        public int Damage;

        public EnemyCombatData(int health, int damage)
        {
            Health = health;
            Damage = damage;
        }
        
    }
}
