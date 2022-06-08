using UnityEngine;

namespace Events
{
    public class GameEvents : MonoBehaviour
    {
        public delegate void LoadAmmo();
        public static event LoadAmmo OnLoadAmmo;

        public static void OnLoadAmmoMethod()
        {
            if (OnLoadAmmo != null)
            {
                OnLoadAmmo();
            }
        }
        public delegate void Victory();
        public static event Victory OnVictory;

        public static void OnVictoryMethod()
        {
            if (OnVictory != null)
            {
                OnVictory();
            }
        }
    }
}