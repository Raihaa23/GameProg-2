using UnityEngine;

namespace Data.Ammo
{
    [CreateAssetMenu(fileName = "newAmmoData", menuName = "Data/Ammo Data/Base Data", order = 0)]
    public class AmmoData : ScriptableObject
    {
        public float damageMultiplier;
        public float specialDamage;
    }
}