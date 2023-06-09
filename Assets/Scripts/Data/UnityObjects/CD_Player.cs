using Data.ValueObjects;
using UnityEngine;

namespace Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Player", menuName = "OurProject/CD_Player", order = 0)]
    public class CD_Player : ScriptableObject
    {
        public PlayerData Data;

        public void SetHealth(int health)
        {
            Data.combatData.Health = health;
        }
        public void Heal(int health)
        {
            Data.combatData.Health += health;
        }
        public void DamageMulti(int dmgmulti)
        {
            Data.combatData.Damage *= dmgmulti;
        }
    }
}