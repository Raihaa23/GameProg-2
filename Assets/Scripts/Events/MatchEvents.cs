using UnityEngine;

namespace Events
{
    public class MatchEvents : MonoBehaviour
    { // EVENTS FOR CURRENT MATCH RELATED ACTIONS
        public delegate void CheckVictory();
        public static event CheckVictory OnCheckVictory;
        public static void OnVictoryMethod()
        {
            if (OnCheckVictory != null)
            {
                OnCheckVictory();
            }
        }
        
        public delegate void CountToEnd();
        public static event CountToEnd OnCountToEnd;
        public static void OnCountToEndMethod()
        {
            if (OnCountToEnd != null)
            {
                OnCountToEnd();
            }
        }
    }
}