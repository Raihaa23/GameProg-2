using UnityEngine;

namespace Events
{
    public class DataEvents : MonoBehaviour
    { // EVENTS FOR DATA MANIPULATION
        public delegate void ResetPlayerData();
        public static event ResetPlayerData OnResetPlayerData;
        public static void OnResetPlayerDataMethod()
        {
            if (OnResetPlayerData != null)
            {
                OnResetPlayerData();
            }
        }
    }
}