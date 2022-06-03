using UnityEngine;

namespace Data.NPC
{
    [CreateAssetMenu(fileName = "newNPCData", menuName = "Data/NPC Data/Base Data", order = 0)]
    public class NpcData : ScriptableObject
    {
        public float health = 50;
    }
}