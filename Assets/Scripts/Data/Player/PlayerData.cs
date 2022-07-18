using UnityEngine;

namespace Data.Player
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public string playerName;
        public string enemyDestructible;
        public int enemyAmmoLayer;
        public string equippedAmmo;

        public float totalIntegrity;
        public float currentIntegrity;
        
        public bool canDoAction;
        public bool isKingDead = false;

    }
}