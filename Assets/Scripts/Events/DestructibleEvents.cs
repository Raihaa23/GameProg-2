using UnityEngine;

namespace Events
{
    public class DestructibleEvents : MonoBehaviour
    { // EVENTS FOR DESTRUCTIBLE ACTIONS
        public delegate void CalculateHp();
        public static event CalculateHp OnCalculateHp;
        public static void OnCalculateHpMethod()
        {
            if (OnCalculateHp != null)
            {
                OnCalculateHp();
            }
        }
    }
}