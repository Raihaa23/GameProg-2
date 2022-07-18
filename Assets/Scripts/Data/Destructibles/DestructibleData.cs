using UnityEngine;

namespace Data.Destructibles
{
    [CreateAssetMenu(fileName = "newDestructibleData", menuName = "Data/Destructible Data/Base Data", order = 0)]
    public class DestructibleData : ScriptableObject
    {
        public float health = 50;
        public float damageMultiplier;
        public string npcType;
    }
}